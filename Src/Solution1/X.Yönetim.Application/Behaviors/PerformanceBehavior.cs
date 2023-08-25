using ArxOne.MrAdvice.Advice;
using Nest;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.Yönetim.Application.Behaviors
{
    public class PerformanceBehaviorÇ : Attribute, IMethodAdvice
    {
        public void Advise(MethodAdviceContext context)
        {
            Stopwatch watch = new Stopwatch();
            //Kronometreyi başlat
            watch.Start();

            context.Proceed();

            //Kronometreyi durdur
            watch.Stop();

            var totalDuration = watch.Elapsed.TotalSeconds;

            Log.Information($"{context.TargetName} metodu {totalDuration} saniyede tamamlandı.");
        }
    }
}

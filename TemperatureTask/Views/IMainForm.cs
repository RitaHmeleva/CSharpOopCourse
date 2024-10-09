using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureTask.Views
{
    internal interface IMainForm
    {
        public void SetSourceScales(List<string> scales);

        public void SetTargetScales(List<string> scales);

        public void SetSourceTemperature(double value);

        public void SetTargetTemperature(double value);

        public void SetSourceScale(int index);

        public void SetTargetScale(int index);
    }
}

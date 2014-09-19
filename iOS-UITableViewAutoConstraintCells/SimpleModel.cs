using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Empty1
{
    public class SimpleModel : BaseModel
    {
        private SimpleModel()
            : base()
        {
        }

        public List<Field> Fields;

        private static SimpleModel _simpleModel;

        public static SimpleModel Instance()
        {
            if (_simpleModel == null)
            {
                _simpleModel = new SimpleModel();
                _simpleModel.PopulateData();
            }
            return _simpleModel;
        }

        private void PopulateData()
        {
            Fields = new List<Field>();
            foreach (string name in Names)
            {
                Fields.Add(new Field(Columns[0]) { Value = GenerateRandomLoremIpsum() });
            }
        }

        //private void PopulateData()
        //{
        //    Fields = new List<Field>();
        //    foreach (string name in Names)
        //    {
        //        Fields.Add(new Field(Columns[0]) { Value = name });
        //    }
        //}
    }
}
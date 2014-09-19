using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Empty1
{
    public class Column
    {
        public string Name { get; set; }
        public string Caption { get; set; }
        public bool MultiLine { get; set; }
    }

    public class Field
    {
        public Field(Column column)
        {
            this.Column = column;
        }
        public string Value { get; set; }
        public Column Column { get; private set; }
    }

    public class Record
    {
        public Record()
        {
            Fields = new List<Field>();
        }

        public IList<Field> Fields { get; private set; }
    }

    public class ComplexModel : BaseModel
    {
        private const int MaxRecords = 5;

        private static ComplexModel _model;

        private ComplexModel()
            :base()
        {
            Records = new List<Record>();
        }

        public static ComplexModel Instance()
        {
            if (_model == null)
            {
                _model = new ComplexModel();
                _model.PopulateData();
            }
            return _model;
        }

        public IList<Record> Records { get; private set; }

        // Generate Records with 5 fields, one of which is multiline
        private void PopulateData()
        {
            CreateColumns();
            for (int i = 0; i < MaxRecords; i++)
            {
                Records.Add(CreateRecord(i));
            }
        }

        private Record CreateRecord(int i)
        {
            Record record = new Record();
            record.Fields.Add(new Field(Columns[0]) { Value = Names[random.Next(0, Names.Length-1)] });
            record.Fields.Add(new Field(Columns[1]) { Value = UIFont.FamilyNames[random.Next(UIFont.FamilyNames.Length)] });
            record.Fields.Add(new Field(Columns[2]) { Value = GenerateRandomLoremIpsum() });
            record.Fields.Add(new Field(Columns[3]) { Value = loremIpsumParts[random.Next(0, loremIpsumParts.Length - 1)] });
            record.Fields.Add(new Field(Columns[4]) { Value = loremIpsumParts[random.Next(0, loremIpsumParts.Length - 1)] });
            return record;
        }


    }
}
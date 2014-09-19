using System.Collections.Generic;

namespace SearchSample
{
    public static class SampleData
    {
        public static List<GuidIndexedDataItem> GetData()
        {
            var people = new List<GuidIndexedDataItem>
            {
                new GuidIndexedDataItem("DA640DF5-1C9D-480D-BF88-003F3565CACB", "L", "Lukasz Glowinski"),
                new GuidIndexedDataItem("4BDCC18F-A5F8-420D-9AEA-007371D026C4", "P", "Peter Eckford"),
                new GuidIndexedDataItem("6DFC63A2-CE82-43D2-A0FF-02799E09C47E", "R", "Robert Andrew"),
                new GuidIndexedDataItem("A6CF1EAA-7C84-4C57-AFA0-048AE98EDA5C", "J", "Jack Ralph"),
                new GuidIndexedDataItem("B666DFF3-7AFD-4ABE-846F-0642F4F40EBF", "D", "David Ryder"),
                new GuidIndexedDataItem("EF004922-3CC2-4005-8948-07103F134FC9", "B", "Bob Bratcher"),
                new GuidIndexedDataItem("0E8AE0DA-F451-44F0-AF09-07377D862346", "R", "Roy Brown"),
                new GuidIndexedDataItem("7ECBD854-5ED8-4616-A3C5-086BD2FCE991", "S", "Scott Newton"),
                new GuidIndexedDataItem("510E27AE-A402-4586-A261-089390D53FE7", "S", "Steven Kirby"),
                new GuidIndexedDataItem("92228237-649F-4124-820C-08A122339359", "A", "Andrew Beeley"),
                new GuidIndexedDataItem("81BE7870-B944-4A6A-8EBC-0AC45523BB91", "S", "Steve Davis"),
                new GuidIndexedDataItem("09FED0F9-1991-4226-B1DF-0BC2BE27529E", "I", "Ian Ralphs"),
                new GuidIndexedDataItem("61AF955D-DC2C-4005-878D-0CFB244C9215", "C", "Calvin Koo"),
                new GuidIndexedDataItem("ABBA7EDD-3ED4-420A-817B-0D7BE0EFF077", "H", "Harrison Wyatt"),
                new GuidIndexedDataItem("EB68E78A-FF41-4C0A-B125-0E7776F99617", "J", "John Hodgkiss"),
                new GuidIndexedDataItem("F63D7510-4815-455E-9304-0ED1BEAC38FD", "D", "Dan Greenhalgh"),
                new GuidIndexedDataItem("1FBBDD08-4C93-47F4-9C4C-1007444C6173", "R", "Rachel Price"),
                new GuidIndexedDataItem("4949DB7E-C01A-45D1-9121-10D24C756302", "C", "Charles Hook")
            };

            return people;
        }
    }
}
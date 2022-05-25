namespace VerticeLibTests.Strings
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StringsTest
    {
        [TestMethod]
        public void TestAfter()
        {
            string test1 = "A = B ";

            // Must return string after delimiter = without trimming.
            Assert.AreEqual(" B ", VerticeLib.Strings.Strings.After(test1, "="));

            // Must return trimmed string after delimiter =
            Assert.AreEqual("B", VerticeLib.Strings.Strings.After(test1, "=", true));

            // Must return string after first delimiter is found.
            Assert.AreEqual("= B ", VerticeLib.Strings.Strings.After(test1, " "));

            // Must return trimmed string after first delimiter is found.
            Assert.AreEqual("= B", VerticeLib.Strings.Strings.After(test1, " ", true));

            // Must return string.Empty if delimiter is not found
            Assert.AreEqual(string.Empty, VerticeLib.Strings.Strings.After(test1, "?"));
            Assert.AreEqual(string.Empty, VerticeLib.Strings.Strings.After(test1, "?", true));

            // Compounded delimiter: Must return string after first delimiter is found.
            Assert.AreEqual(" ", VerticeLib.Strings.Strings.After(test1, "= B"));

            // Compounded delimiter: Must return trimmed string after first delimiter is found.
            Assert.AreEqual(string.Empty, VerticeLib.Strings.Strings.After(test1, "= B", true));

            // Working with multi-line text.
            string test2 = @"A

 = B ";

            Assert.AreEqual(" B ", VerticeLib.Strings.Strings.After(test2, "="));
            Assert.AreEqual("B", VerticeLib.Strings.Strings.After(test2, "=", true));
            Assert.AreEqual(" = B ", VerticeLib.Strings.Strings.After(test2, System.Environment.NewLine + System.Environment.NewLine));
            Assert.AreEqual("= B", VerticeLib.Strings.Strings.After(test2, System.Environment.NewLine + System.Environment.NewLine, true));
        }
    }
}

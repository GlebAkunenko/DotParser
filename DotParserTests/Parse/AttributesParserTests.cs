﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotParser.Parse;
using Attribute = DotParser.DOT.Attribute;
using System.Reflection.Metadata;

namespace DotParser.Parse.Tests
{
    [TestClass]
    public class AttributesParserTests
    {
        [TestMethod]
        public void FromString_2attr_parseSuccess()
        {
            string input = "[shape=box, info = 123]";
            
            Attribute[] externed = new Attribute[] {
                new Attribute("shape", "box"),
                new Attribute("info", "123")
            };

            Attribute[] actual = AttributesParser.FromString(input);

            CollectionAssert.AreEqual(externed, actual);
        }

        [TestMethod]
        public void FromString_1attr_parseSuccess()
        {
            string input = "[shape = box]";

            Attribute[] externed = new Attribute[] {
                new Attribute("shape", "box")
            };

            Attribute[] actual = AttributesParser.FromString(input);

            CollectionAssert.AreEqual(externed, actual);
        }

        [ExpectedException(typeof(DotSyntaxException))]
        [TestMethod]
        public void FromString_wrongSyntax_exeptionExpected()
        {
            string input = "[shape = box, info==true]";
            AttributesParser.FromString(input);
        }


    }
}
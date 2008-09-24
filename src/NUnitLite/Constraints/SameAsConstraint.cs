// *****************************************************
// Copyright 2007, Charlie Poole
//
// Licensed under the Open Software License version 3.0
// *****************************************************

using System;

namespace NUnit.Framework.Constraints
{
    /// <summary>
    /// SameAsConstraint tests whether an object is identical to
    /// the object passed to its constructor
    /// </summary>
    public class SameAsConstraint : Constraint
    {
        private object expected;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SameAsConstraint"/> class.
        /// </summary>
        /// <param name="expected">The expected object.</param>
        public SameAsConstraint(object expected)
        {
            this.expected = expected;
        }

        /// <summary>
        /// Test whether the constraint is satisfied by a given value
        /// </summary>
        /// <param name="actual">The value to be tested</param>
        /// <returns>True for success, false for failure</returns>
        public override bool Matches(object actual)
        {
            this.actual = actual;

#if NETCF_1_0
            // TODO: THis makes it compile, now make it work.
            return expected.Equals(actual);
#else
            return Object.ReferenceEquals(expected, actual);
#endif
        }

        /// <summary>
        /// Write the constraint description to a MessageWriter
        /// </summary>
        /// <param name="writer">The writer on which the description is displayed</param>
        public override void WriteDescriptionTo(MessageWriter writer)
        {
            writer.WritePredicate("same as");
            writer.WriteExpectedValue(expected);
        }
    }
}

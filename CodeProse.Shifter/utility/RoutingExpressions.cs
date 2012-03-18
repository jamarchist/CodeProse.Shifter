﻿namespace CodeProse.Shifter.utility
{
    public static class RoutingExpressions
    {
        /// <summary>
        /// Routes a guid to variable named 'guid'
        /// </summary>
        public const string Guid = @"/(?<guid>[A-Za-z0-9]{8}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{12})";

        /// <summary>
        /// Routes a dash-separated name combination to variables
        /// 'firstname' and 'lastname'
        /// </summary>
        public const string FirstNameLastName = @"/(?<firstname>[\w]{1,20})(?<dash>[\-]{1})(?<lastname>[\w]{1,20})";
    }
}
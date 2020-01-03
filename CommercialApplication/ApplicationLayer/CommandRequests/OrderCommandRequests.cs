using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.ApplicationLayer.CommandRequests
{
    public static class OrderCommandRequests
    {
        public const string GetOrder = "GetOrder";
        public const string GetMaxSumValueOrderForDay = "GetMaxSumValueOrderForDay";
        public const string GetMinSumValueOrderForDay = "GetMinSumValueOrderForDay";
        public const string Update = "Update";
        public const string Insert = "Insert";
        public const string Delete = "Delete";
        public const string SetState = "SetState";
    }
}

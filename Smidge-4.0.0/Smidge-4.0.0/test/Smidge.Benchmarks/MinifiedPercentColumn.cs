﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace Smidge.Benchmarks
{
    /// <summary>
    /// Once the benchmarks have executed this will go execute the method to get the resulting byte count of the minified version 
    /// for the method being called.
    /// </summary>
    /// <remarks>
    /// ref: https://github.com/PerfDotNet/BenchmarkDotNet/issues/180
    ///      https://github.com/Bobris/BTDB/blob/bd1cd1ecc825e74c156fbe23c126fd582dd505c9/SimpleTester/EventSerializationBenchmark.cs#L86
    /// </remarks>
    public class MinifiedPercentColumn : IColumn
    {
        public string Id => "MinifiedPercentage";
        public string Legend => ColumnName;
        public bool AlwaysShow => true;
        public string ColumnName => "Minified %";
        public bool IsAvailable(Summary summary) => true;

        public string GetValue(Summary summary, BenchmarkCase benchmarkCase)
        {
            throw new NotSupportedException("TODO: Need to figure out how to get this compiling again ... though it's not really important");

            //var target = benchmark.Target;
            //var instance = (JsMinifyBenchmarks)Activator.CreateInstance(target.Type);
            //target.Method.Invoke(instance, new object[0]);
            //var methodName = "Get" + target.MethodDisplayInfo;
            //var result = ((Task<string>)target.Type.GetMethod(methodName).Invoke(instance, new object[0])).Result;
            //var original = (string)target.Type.GetField("JQuery").GetValue(null);


            //return ((double)Encoding.UTF8.GetByteCount(result) / Encoding.UTF8.GetByteCount(original))
            //    .ToString("P2", new NumberFormatInfo { PercentPositivePattern = 1, PercentNegativePattern = 1 }); ;
        }

        public string GetValue(Summary summary, BenchmarkCase benchmarkCase, SummaryStyle style)
        {
            return GetValue(summary, benchmarkCase);
        }

        public bool IsDefault(Summary summary, BenchmarkCase benchmarkCase) => false;

        //public bool AlwaysShow => true;
        public ColumnCategory Category => ColumnCategory.Statistics;
        public int PriorityInCategory => 0;
        public bool IsNumeric => true;
        public UnitType UnitType => UnitType.Dimensionless;
        
        
    }
}
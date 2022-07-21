// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using NExpression.BenchMark;

var summary = BenchmarkRunner.Run<TestBenchmark>();
Console.WriteLine(summary);
Console.ReadLine();
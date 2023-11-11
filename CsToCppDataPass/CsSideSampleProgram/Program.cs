// See https://aka.ms/new-console-template for more information
using CsSideSampleProgram;

SAMPLE_STRUCT sampleData = new SAMPLE_STRUCT();
sampleData.ParamA = 10;
sampleData.ParamB = 23;
sampleData.Result = -1;

long res = CppSideIF.CppSideSampleIF(ref sampleData);

Console.WriteLine($"   res = {res}");
Console.WriteLine($"Result = {sampleData.Result}");

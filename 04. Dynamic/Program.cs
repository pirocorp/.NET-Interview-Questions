namespace Dynamic
{
    using System;
    using IronPython.Hosting;

    public static class Program
    {
        public static void Main()
        {
            dynamic variable = "123";
            
            variable.MethodNotExists();

            var toUpper = variable.ToUpper();

            var cast = (string) variable;

            Console.WriteLine(RunPython());
        }

        public static dynamic RunPython()
        {
            const string pythonScript =
            @"class PythonClass:
            def toUpper(self, input):
                return input.upper()";

            var engine = Python.CreateEngine();
            var scope = engine.CreateScope();
            var operations = engine.Operations;

            engine.Execute(pythonScript, scope);
            var pythonClassObject = scope.GetVariable("PythonClass");
            var instance = operations.CreateInstance(pythonClassObject);

            return instance.toUpper("Hello World!");
        }
    }
}
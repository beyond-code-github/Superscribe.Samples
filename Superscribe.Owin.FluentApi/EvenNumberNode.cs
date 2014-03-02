namespace Superscribe.Samples.FluentApi
{
    using Superscribe.Models;

    public class EvenNumberNode : GraphNode
    {
        public EvenNumberNode(string name)
        {
            this.activationFunction = (routeData, value) =>
            {
                int parsed;
                if (int.TryParse(value, out parsed))
                    return parsed % 2 == 0; // Only match even numbers

                return false;
            };

            this.ActionFunctions.Add("Set_" + name, (routeData, value) =>
            {
                int parsed;
                if (int.TryParse(value, out parsed))
                    routeData.Parameters.Add(name, parsed);
            });
        }
    }
}
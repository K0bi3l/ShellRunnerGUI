namespace Jetbrains_1
{
    public enum OutputType
    {
        Input,
        Output,
        Error,
    }

    public class OutputColorManager
    {
        Dictionary<OutputType, Color> TypeColorDic = new()
        {
            { OutputType.Input, Color.Orange },
            { OutputType.Output, Color.White },
            { OutputType.Error, Color.Red }
        };

        public Color GetColor(OutputType type)
        {
            if (TypeColorDic.ContainsKey(type))
            {
                return TypeColorDic[type];
            }
            else
            {
                throw new ArgumentException("Invalid output type");
            }

        }
    }
}

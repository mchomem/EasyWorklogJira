namespace EasyWorklogJira.Core.Application.Extensions;

public static class EnumExtension
{
    public static string GetDescription(this Enum value)
    {
        // Obtém o tipo do enum
        Type type = value.GetType();

        // Obtém o campo (membro) do enum pelo nome
        FieldInfo fieldInfo = type.GetField(value.ToString());

        // Se o campo for nulo, retorna uma string vazia ou o nome do enum
        if (fieldInfo == null)
        {
            return string.Empty;
        }

        // Obtém o atributo Description do campo
        DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

        // Se o atributo existir, retorna a descrição; caso contrário, retorna o nome do enum
        return attributes.Length > 0 ? attributes[0].Description : value.ToString();
    }
}

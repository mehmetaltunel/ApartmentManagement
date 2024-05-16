namespace ApartmentManagement.Core.Utils;

public class BusinessRuleExceptionKey
{
    public static string NO_CHANGE(string modelName) => $"{modelName}_NO_CHANGE";
    public static string USED(string modelName, string propertyName) => $"{modelName}_{propertyName}_USED";
    public static string NOT_FOUND(string modelName) => $"{modelName}_NOT_FOUND";
    public static string NOT_EMPTY(string modelName, string propertyName) => $"{modelName}_{propertyName}_NOT_EMPTY";
    public static string MIN_LENTGH(string modelName, string propertyName, int value) => $"{modelName}_{propertyName}_MIN_LENTGH_{value}";
    public static string MAX_LENTGH(string modelName, string propertyName, int value) => $"{modelName}_{propertyName}_MAX_LENTGH_{value}";
    public static string ONLY_LETTER(string modelName, string propertyName) => $"{modelName}_{propertyName}ONLY_LETTER";
    public static string ONLY_NUMBER(string modelName, string propertyName) => $"{modelName}_{propertyName}ONLY_NUMBER";
    public static string ONLY_ONE_SPACE(string modelName, string propertyName) => $"{modelName}_{propertyName}ONLY_ONE_SPACE";
    public static string STARTS_WITH_UPPERCASE(string modelName, string propertyName) => $"{modelName}_{propertyName}STARTS_WITH_UPPERCASE";
    public static string NOT_EDITABLE(string modelName) => $"{modelName}_NOT_EDITABLE";


    public static string ROLE_CONTAINS_USER = "ROLE_CONTAINS_USER";
    public static string GENERAL = "GENERAL";
    public static string CATEGORY_ORDER_IF_NOT_NULL_GREATER_THAN_ZERO = "CATEGORY_ORDER_IF_NOT_NULL_GREATER_THAN_ZERO";
    public static string DATABASE_ERROR = "DATABASE_ERROR";

}
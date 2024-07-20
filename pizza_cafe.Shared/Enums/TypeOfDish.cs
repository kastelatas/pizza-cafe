namespace pizza_cafe.Shared.Enums;

public enum TypeOfDish
{
    FirstDish = 1,
    SecondDish,
    SaladsAndSnacks,
    HotDog,
    Supplements,
    Drink,
    Pizza
}

public static class TypeOfDishExtensions
{
    public static string ToReadableString(this TypeOfDish typeOfDish)
    {
        switch (typeOfDish)
        {
            case TypeOfDish.FirstDish:
                return "Перші страви";
            case TypeOfDish.SecondDish:
                return "Другі страви";
            case TypeOfDish.SaladsAndSnacks:
                return "Салати та закуски";
            case TypeOfDish.HotDog:
                return "Хот Доги";
            case TypeOfDish.Supplements:
                return "Закуски у фритюрі";
            case TypeOfDish.Drink:
                return "Напої";
            case TypeOfDish.Pizza:
                return "Піца";
            default:
                return typeOfDish.ToString();
        }
    }
}
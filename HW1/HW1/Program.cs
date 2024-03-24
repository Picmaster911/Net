using HW1;
using System.Text;

Console.WriteLine("Input number fot calculate factorial");

var success = false;
var result = 0;

do
{
    var numFromUser = Console.ReadLine();
    success = int.TryParse(numFromUser, out result);
    if (!success)
        Console.WriteLine("Input valid number - You can enter only numbers ");
    Console.WriteLine($"{RotateNumber(result)}");
    Console.WriteLine($"{ShiftStep(result, 3)}");
    Console.WriteLine($"{Facrorial(result)}");
    ArrInsertValue();

}
while (!success);

int RotateNumber(int inNumber)
{ 
    var strNumber = inNumber.ToString();
    strNumber = new string(strNumber.ToString().Reverse().ToArray());
    return  int.Parse(strNumber);
}

int ShiftStep (int inNumber, int step)
{
    var strNumber = inNumber.ToString();
    StringBuilder sbP1 = new StringBuilder(strNumber);
    StringBuilder sbP2 = new StringBuilder();
    if (step <= sbP1.Length)
    {
        for (int i = 0; i < step; i++)
        {
            sbP2.Append(sbP1[i]);
        }
        sbP1.Remove(0, step);
        var result = sbP1.Append(sbP2.ToString()).ToString();
        return int.Parse(result);
    }
    return inNumber;
}
long Facrorial(int inNumber)
{
    long result = 1;

    for (int i = 1; i <= inNumber; i++)
    {
        result = i * result;
    }
    return result;
}

void ArrInsertValue ()
{
    Random rnd = new Random();
    var arrInt = new int[5, 5];
    int rows = arrInt.GetLength(0);
    int columns = arrInt.GetLength(1);
    for (int r = 0; r < rows; r++)
    {
        for (int c = 0; c < columns; c++)
        {
            arrInt[r, c] = rnd.Next(-100,100);
            Console.WriteLine($"{arrInt[r, c]}");
        }            
    }
    getSumArrMaxMinVal(arrInt);
}

void getSumArrMaxMinVal(int[,] arr)
{
    var maxValue = arr.Cast<int>().Max();
    var maxIndex = arr.Cast<int>().ToList().IndexOf(maxValue);
    var minValue = arr.Cast<int>().Min();
    var minIndex = arr.Cast<int>().ToList().IndexOf(minValue);
    if (maxIndex > minIndex)
    {
        var range = arr.Cast<int>().ToList().Where((item, idex) => idex > minIndex && idex < maxIndex).ToList();
        Console.WriteLine($" value = {range.Sum()}");
    }
    else
    {
        var range = arr.Cast<int>().ToList().Where((item, idex) => idex > maxIndex && idex < minIndex).ToList();
        Console.WriteLine($" value = {range.Sum()}");
    }

    var academyGroup = new AcademyGroup();


   // academyGroup.ReadXls();
    academyGroup.Add(new Person("Bob", "Jason", 12, "123-321-3"));
    academyGroup.Add(new Person("Max", "DRdasd", 12, "3123-321"));
    academyGroup.Add(new Person("Vlad", "Borisov", 12, "3213-321"));
    academyGroup.Add(new Person("Ivan", "Ivanov", 12, "3123"));
    //academyGroup.Remove("DRdasd");
    academyGroup.Edite("DRdasd", "New");
    academyGroup.SaveXls();
    academyGroup.Print();
}
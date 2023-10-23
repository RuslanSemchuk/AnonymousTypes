using System;
using System.Text;

public class LargeNumber
{
    private string value;

    public LargeNumber(string value)
    {
        this.value = value;
    }

    public LargeNumber(long value)
    {
        this.value = value.ToString();
    }

    public LargeNumber Add(LargeNumber other)
    {
        string result = AddStrings(this.value, other.value);
        return new LargeNumber(result);
    }

    public LargeNumber Subtract(LargeNumber other)
    {
        string result = SubtractStrings(this.value, other.value);
        return new LargeNumber(result);
    }

    public override string ToString()
    {
        return value;
    }

    private static string AddStrings(string num1, string num2)
    {
        StringBuilder result = new StringBuilder();
        int carry = 0;
        int i = num1.Length - 1;
        int j = num2.Length - 1;

        while (i >= 0 || j >= 0 || carry > 0)
        {
            int x = (i >= 0) ? num1[i] - '0' : 0;
            int y = (j >= 0) ? num2[j] - '0' : 0;
            int sum = x + y + carry;

            result.Insert(0, sum % 10);
            carry = sum / 10;

            i--;
            j--;
        }

        return result.ToString();
    }

    private static string SubtractStrings(string num1, string num2)
    {
        StringBuilder result = new StringBuilder();
        int borrow = 0;
        int i = num1.Length - 1;
        int j = num2.Length - 1;

        while (i >= 0)
        {
            int x = num1[i] - '0';
            int y = (j >= 0) ? num2[j] - '0' : 0;
            int diff = x - y - borrow;

            if (diff < 0)
            {
                diff += 10;
                borrow = 1;
            }
            else
            {
                borrow = 0;
            }

            result.Insert(0, diff);
            i--;
            j--;
        }


        int index = 0;
        while (index < result.Length - 1 && result[index] == '0')
        {
            index++;
        }
        result.Remove(0, index);

        return result.ToString();
    }
}

class Program
{
    static void Main(string[] args)
    {
        LargeNumber num1 = new LargeNumber("123456789012345678901234567890");
        LargeNumber num2 = new LargeNumber("987654321098765432109876543210");

        LargeNumber sum = num1.Add(num2);
        LargeNumber difference = num1.Subtract(num2);

        Console.WriteLine("num1 + num2 = " + sum);
        Console.WriteLine("num1 - num2 = " + difference);
    }
}

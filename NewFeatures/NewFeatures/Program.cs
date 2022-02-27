using System;
using System.Threading.Channels;
using NewFeatures;

#region 9.0 Features

/*RECORDS*/
Person p1 = new("Narish", "Singh");
Console.WriteLine(p1);

//val eq
string[] nums = new string[2];
Person2 p2 = new("Nancy", "Devolio", nums);
Person2 p3 = new("Nancy", "Devolio", nums);
nums[0] = "555-555-5555";
Console.WriteLine(p2 == p3); //val eq == true
Console.WriteLine(ReferenceEquals(p2, p3)); //ref eq == false

//mutation
Person2 p4 = p2 with { FirstName = "Johnny" };
Console.WriteLine(p4);
Console.WriteLine(p2 == p4); //false

//inheritance
PersonAbstract teacher1 = new Teacher("Jane", "Doe", 3);
PersonAbstract student1 = new Student("Young", "Student", 3);
PersonAbstract student2 = student1 with { FirstName = "Newest" };
Console.WriteLine(teacher1);
Console.WriteLine(teacher1 == student1);
Console.WriteLine(student1 == student2);

//init only setters
WeatherObservation weatherNow = new()
{
    RecordedAt = DateTime.Now,
    TempC = 20,
    PressureMB = 998.0m
}; //new expression
//weatherNow.TempC = 18; //this is readonly

/*PATTERN MATCHING*/
char c1 = 'g';
char c2 = ',';
Console.WriteLine(c1.IsLetter());
Console.WriteLine(c2.IsLetter());
Console.WriteLine(c2.IsLetterOrSeparator());

if (c1 as char? is not null)
{
    Console.WriteLine("Not null!");
}

#endregion

#region 8.0 FEATURES

/*Default Interface methods*/
SampleCust cust1 = new("c1", new DateTime(2010, 5, 31))
{
    Reminders =
    {
        { new DateTime(2010, 8, 12), "Bday" },
        { new DateTime(2012, 11, 15), "Anniv" }
    }
};
SampleOrder o1 = new(new DateTime(2012, 6, 1), 5m);

cust1.AddOrder(o1);

ICustomer theCust = cust1; //must cast to the type of interface in order to use this
Console.WriteLine($"Current discount: {theCust.ComputeLoyaltyDiscount()}");

/*Switch*/
RgbColor myColor = RgbColor.FromRainbow(Rainbow.Violet);
Console.WriteLine(myColor);

Console.WriteLine($"{Address.ComputerSalesTax(new Address { State = "MI" }, 99.99m):C}"); //property pattern

Point pt1 = new Point(10, -99);
Point pt2 = new Point(0, 0);
Point pt3 = new Point(-9, -19);
Console.WriteLine(Point.GetQuadrant(pt1));
Console.WriteLine(Point.GetQuadrant(pt2));
Console.WriteLine(Point.GetQuadrant(pt3));

/*Using Statement*/
int skipped = UsingWriter.WriteLinesTofile(new[] { "First", "Second", "Third", "Fourth", "Fifth" });
Console.WriteLine($"skipped = {skipped}");


/*Async Streams*/
await foreach (int num in AsyncStreamNumbers.GenerateSequence())
{
    Console.WriteLine(num);
}

/*idx and range operators*/
int[] hundredNums = Enumerable.Range(0, 100).ToArray();
Console.WriteLine($"Last num: {hundredNums[^1]}");
Console.WriteLine($"2nd to last num: {hundredNums[^2]}");
Console.WriteLine($"39th to last num: {hundredNums[^39]}");

Console.WriteLine($"{string.Join(",", hundredNums[..50])}"); //from beginning
Console.WriteLine($"{string.Join(",", hundredNums[50..])}"); //from end
Console.WriteLine($"{string.Join(",", hundredNums[25..75])}"); //in range, lower bound exclusive
Console.WriteLine($"{string.Join(",", hundredNums[^75..^25])}"); //in range, lower bound exclusive also
Console.WriteLine($"{string.Join(",", hundredNums[..])}"); //the entire arr

Range firstTen = 1..10;
Console.WriteLine($"{string.Join(",", hundredNums[firstTen])}"); //use of range as a variable

/*Null coalescing assignment*/
List<int> nullNums = null;
int? i = null;

nullNums ??= new List<int>();
nullNums.Add(i ??= 17); //will assign
nullNums.Add(i ??= 20); //will not assign

Console.WriteLine(string.Join(",", nullNums));

#endregion
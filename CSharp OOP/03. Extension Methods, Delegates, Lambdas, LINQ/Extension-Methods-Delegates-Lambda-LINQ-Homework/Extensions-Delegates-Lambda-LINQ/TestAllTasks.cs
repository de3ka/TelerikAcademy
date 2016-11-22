using Extensions_Delegates_Lambda_LINQ._01.StringBuilder_Extension_Methods;
using Extensions_Delegates_Lambda_LINQ._02.IEnumerable_Extension_Methods;
using Extensions_Delegates_Lambda_LINQ._03_05.Students;
using Extensions_Delegates_Lambda_LINQ._06.Divisible_By_7_And_3;
using Extensions_Delegates_Lambda_LINQ._07.Timer;
using Extensions_Delegates_Lambda_LINQ._17.Longest_String;
using Extensions_Delegates_Lambda_LINQ._09_15.Student_Groups;
using Extensions_Delegates_Lambda_LINQ._18_19.GroupedBy;

namespace Extensions_Delegates_Lambda_LINQ
{
    public class TestAllTasks
    {
        static void Main(string[] args)
        {
            StringBuilderExtensionsTests.Test();
            IEnumerableExtensionsTest.Test();
            StudentsTest.Test();
            Demo.Test();
            //remove comment to see Timer Test
            //TimerTest.Test();
            StudentGroupTest.Test();
            LongestStringTest.Test();
            GroupedByTest.Test();
        }
    }
}

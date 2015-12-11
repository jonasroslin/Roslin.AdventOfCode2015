using System.Security.Cryptography;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace Roslin.AdventOfCode.Day4
{
    [TestFixture]
    public class PartOneAndTwo
    {
        [Test]
        [TestCase("pqrstuv", 1048970, "00000")]
        [TestCase("abcdef", 609043, "00000")]
        [TestCase("ckczppom", 117946, "00000")]
        [TestCase("ckczppom", 3938038, "000000")]
        public void Should_be_able_to_find_correct_part_of_key(string key, int result, string startsWith)
        {
            var i = 0;
            while (true)
            {
                var calculateMd5Hash = CalculateMd5Hash(key + i);
                if (calculateMd5Hash.StartsWith(startsWith))
                    break;
                i++;
            }

            i.Should().Be(result);
        }

        public string CalculateMd5Hash(string input)
        {
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hash = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            foreach (var b in hash)
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}

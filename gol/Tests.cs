using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Givn;
using NUnit.Framework;

namespace gol
{
    [TestFixture]
    public class RenderingTests
    {
        private List<Cell> _cells;
        private string _result;

        [Test]
        public void RenderASmallSystem()
        {
            Giv.n(ASmallSystem);
            Wh.n(ItIsRendered);
            Th.n(() => ItShouldRenderDimensions(8, 17))
                .And(() => LivingCellCountIs(_cells.Count));
        }

        private void ASmallSystem()
        {
            _cells = new List<Cell> { new Cell(1,0), new Cell(0,1), new Cell(2,1), new Cell(7,16) };
        }

        private void ItIsRendered()
        {
            _result = GameOfLife.Render(_cells);
        }

        private void ItShouldRenderDimensions(int x, int y)
        {
            Assert.AreEqual(x*y, CountOccurances(_result,"<div"));
        }

        private void LivingCellCountIs(int count)
        {
            Assert.AreEqual(count, CountOccurances(_result,"on"));
        }

        private static int CountOccurances(string source, string sub)
        {
            return source.Select((c, i) => source.Substring(i)).Count(s => s.StartsWith(sub));
        }
    }
}

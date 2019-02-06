using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkripsiV2
{
    public class GeneratedWord
    {
        private int direction;
        private int startX;
        private int startY;
        private int numOfIntersections;
        private double intersectionScore;
        private string word;

        public GeneratedWord(string word, int direction, int startX, int startY)
        {
            this.word = word;
            this.direction = direction;
            this.startX = startX;
            this.startY = startY;
            this.numOfIntersections = 0;
            this.intersectionScore = 0.0;
        }

        public int getDirection() { return this.direction; }
        public int getStartX() { return this.startX; }
        public int getStartY() { return this.startY; }
        public string getWord() { return this.word; }
        public int getNumIntersections() { return this.numOfIntersections; }
        public double getIntersectionScore() { return this.intersectionScore; }

        public void setNumIntersections(int n)
        {
            this.numOfIntersections = n;
            setIntersectionScore();
        }

        private void setIntersectionScore()
        {
            //Console.WriteLine(this.numOfIntersections + " " + this.word.Length);
            this.intersectionScore = (double)this.numOfIntersections / (double)this.word.Length;
        }
    }
}

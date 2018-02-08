using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
namespace Bots
{

    public class Perceptron:Bot
    {
        double[] Board;
        List<Move> Moves= new List<Move>();
        class Move {
            public double score;
            public Point location;
            public Move(double score, Point location)
            {
                this.score = score;
                this.location = location;
            }
        }
        NeuralNetModel model;
        public Perceptron(int ID, int EnemyId, int EmptyId)
        {
            id = ID;
            enemyId = EnemyId;
            emptyId = EmptyId;
            using (StreamReader r = new StreamReader("model.json"))
            {
                string json = r.ReadToEnd();
                model = new NeuralNetModel(JsonConvert.DeserializeObject<NeuralNetModelRaw>(json));
            }
        }
        public Perceptron()
        {
            using (StreamReader r = new StreamReader("model.json"))
            {
                string json = r.ReadToEnd();
                model = new NeuralNetModel(JsonConvert.DeserializeObject<NeuralNetModelRaw>(json));
            }
        }
        override public Point CalculateMove(int[,] Board)
        {
            this.Board = TwoDToOneD(Board);
            return BestMove(perceptronCalculation(new DenseMatrix( 1, Board.Length, TwoDToOneD(Board))));
        }
        private int translateInt(int i)
        {
            if (i == enemyId)
            {
                return -1;
            }
            if (i== id)
            {
                return 1;
            }
            else if (i == emptyId)
            {
                return 0;
            }
            return i;
        }
        private double[] TwoDToOneD(int[,] boardInt)
        {
            double[] board1D = new double[boardInt.GetLength(0) * boardInt.GetLength(1)];
            for (int i = 0; i < boardInt.GetLength(0); i++)
            {
                for (int j = 0; j < boardInt.GetLength(1); j++)
                {
                    board1D[i * boardInt.GetLength(0) + j] = translateInt(boardInt[i, j]);
                }
            }
            return board1D;
        }
        private Matrix<double> perceptronCalculation(Matrix<double> X)
        {
            Matrix<double> layer_1 = X* model.weights.h1  + model.biases.b1;
            Matrix<double> layer_2 = layer_1*model.weights.h2 + model.biases.b2;
            Matrix<double> layer_out = layer_2 * model.weights.Out + model.biases.Out;
            return layer_out;
        }
        private Point BestMove(Matrix<double> lastLayer)
        {
            int l = (int)Math.Sqrt( lastLayer.ColumnCount);
            double maxDouble = 0; ;
            Point maxPoint = new Point();
            int stJ = 1;
            bool first=true;
            for (int i =0;i<l;i++)
            {
                for (int j = stJ; j < l; j++)
                {
                    if (Board[i * l + j]==0) {
                        if (first) {
                            maxDouble = lastLayer[0, i * l + j];
                            maxPoint = new Point(i, j);
                            first = false;
                        }
                        else
                        if (lastLayer[0, i * l + j] > maxDouble)
                        {
                            maxDouble = lastLayer[0, i * l + j];
                            maxPoint = new Point(i, j);
                        }
                    }
                }
                stJ = 0;
            }
            return maxPoint;
        }
    }
}

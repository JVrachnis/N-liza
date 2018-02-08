using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
namespace Bots
{
    class NeuralNetModel
    {

        public int train_size;
        public Weights weights;
        public Biases biases;
        public int board_size;
        public NeuralNetModel(NeuralNetModelRaw nnmr)
        {
            weights = new Weights(nnmr.weights);
            biases = new Biases(nnmr.biases);
            train_size = nnmr.train_size;
            board_size = nnmr.board_size;
        }
    }
    class Weights
    {
        public Matrix<double> h2;
        public Matrix<double> h1;
        public Matrix<double> Out;
        public Weights(WeightsRaw wr)
        {
            h2 = DenseMatrix.OfArray(wr.h2);
            h1 = DenseMatrix.OfArray(wr.h1);
            Out = DenseMatrix.OfArray(wr.Out);
        }
    }
    class Biases
    {
        public Matrix<double> b1;
        public Matrix<double> b2;
        public Matrix<double> Out;
        public Biases(BiasesRaw br)
        {
            b1 = new DenseMatrix(1, br.b1.Length, br.b1);
            b2 = new DenseMatrix( 1, br.b2.Length, br.b2);
            Out = new DenseMatrix( 1, br.Out.Length, br.Out);
        }
    }
    class NeuralNetModelRaw
    {
        public int train_size;
        public WeightsRaw weights;
        public BiasesRaw biases;
        public int board_size;
    }
    class WeightsRaw
    {
        public double[,] h2;
        public double[,] h1;
        public double[,] Out;
    }
    class BiasesRaw
    {
        public double[] b1;
        public double[] b2;
        public double[] Out;
    }
}

#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <iomanip>
#include <Eigen/Dense>

using Eigen::MatrixXd;
using Eigen::MatrixXf;
using Eigen::VectorXd;
using Eigen::VectorXf;
using namespace std;

ofstream firstMatrixDouble;
ofstream secMatrixDouble;
ofstream thrdMatrixDouble;
ofstream vectorDouble;
ofstream res1Double;
ofstream res2Double;
ofstream res3Double;
ofstream partialDouble;
ofstream fullDouble;

ofstream firstMatrixFloat;
ofstream secMatrixFloat;
ofstream thrdMatrixFloat;
ofstream vectorFloat;
ofstream res1Float;
ofstream res2Float;
ofstream res3Float;
ofstream partialFloat;
ofstream fullFloat;

void CreateFillMatrixAndWriteToFileDouble(int size);
void WriteDoubleFile(MatrixXd doubleMatrix, int size, ofstream &file);
void WriteDoubleFile(VectorXd doubleVector, int size, ofstream &file);

void CreateFillMatrixAndWriteToFileFloat(int size);
void WriteFloatFile(MatrixXf matrix, int size, ofstream &file);
void WriteFloatFile(VectorXf vector, int size, ofstream &file);

int main(int argc, char** argv)
{
	firstMatrixDouble.open("../Output/FirstMatrixDataDouble.txt");
	secMatrixDouble.open("../Output/SecondMatrixDataDouble.txt");
	thrdMatrixDouble.open("../Output/ThirdMatrixDataDouble.txt");
	vectorDouble.open("../Output/VectorDataDouble.txt");
	res1Double.open("../Output/Res1DataDouble.txt");
	res2Double.open("../Output/Res2DataDouble.txt");
	res3Double.open("../Output/Res3DataDouble.txt");
	partialDouble.open("../Output/PartialDataDouble.txt");
	fullDouble.open("../Output/FullDataDouble.txt");

	firstMatrixFloat.open("../Output/FirstMatrixDataFloat.txt");
	secMatrixFloat.open("../Output/SecondMatrixDataFloat.txt");
	thrdMatrixFloat.open("../Output/ThirdMatrixDataFloat.txt");
	vectorFloat.open("../Output/VectorDataFloat.txt");
	res1Float.open("../Output/Res1DataFloat.txt");
	res2Float.open("../Output/Res2DataFloat.txt");
	res3Float.open("../Output/Res3DataFloat.txt");
	partialFloat.open("../Output/PartialDataFloat.txt");
	fullFloat.open("../Output/FullDataFloat.txt");

	int multiplier = 5;

	for (int i = multiplier; i < 100; i += multiplier)
	{
		CreateFillMatrixAndWriteToFileDouble(i);
		CreateFillMatrixAndWriteToFileFloat(i);
	}

	firstMatrixDouble.close();
	secMatrixDouble.close();
	thrdMatrixDouble.close();
	vectorDouble.close();
	res1Double.close();
	res2Double.close();
	res3Double.close();
	partialDouble.close();
	fullDouble.close();

	firstMatrixFloat.close();
	secMatrixFloat.close();
	thrdMatrixFloat.close();
	vectorFloat.close();
	res1Float.close();
	res2Float.close();
	res3Float.close();
	partialFloat.close();
	fullFloat.close();

	int x;
	cout << "Program ended its operation" << endl;
	cin >> x;
	
	return 0;
}

void CreateFillMatrixAndWriteToFileDouble(int size)
{
	MatrixXd matrixA = MatrixXd::Random(size, size);
	MatrixXd matrixB = MatrixXd::Random(size, size);
	MatrixXd matrixC = MatrixXd::Random(size, size);
	VectorXd vector = VectorXd::Random(size);

	VectorXd res1 = matrixA * vector;
	VectorXd res2 = (matrixA + matrixB + matrixC) * vector;
	MatrixXd res3 = matrixA * (matrixB * matrixC);
	//MatrixXd pivLu = matrixA.lu().solve(vector);
	//MatrixXd fullPivLu = matrixA.fullPivLu().solve(vector);

	WriteDoubleFile(matrixA, size, firstMatrixDouble);
	WriteDoubleFile(matrixB, size, secMatrixDouble);
	WriteDoubleFile(matrixC, size, thrdMatrixDouble);
	WriteDoubleFile(vector, size, vectorDouble);

	WriteDoubleFile(res1, size, res1Double);
	WriteDoubleFile(res2, size, res2Double);
	WriteDoubleFile(res3, size, res3Double);
	//WriteDoubleFile(pivLu, size, partialDouble);
	//WriteDoubleFile(fullPivLu, size, fullDouble);
}


void CreateFillMatrixAndWriteToFileFloat(int size)
{
	MatrixXf matrixA = MatrixXf::Random(size, size);
	MatrixXf matrixB = MatrixXf::Random(size, size);
	MatrixXf matrixC = MatrixXf::Random(size, size);
	VectorXf vector = VectorXf::Random(size);

	VectorXf res1 = matrixA * vector;
	VectorXf res2 = (matrixA + matrixB + matrixC) * vector;
	MatrixXf res3 = matrixA * (matrixB * matrixC);
	//MatrixXf pivLu = matrixA.lu().solve(vector);
	//MatrixXf fullPivLu = matrixA.fullPivLu().solve(vector);


	WriteFloatFile(matrixA, size, firstMatrixFloat);
	WriteFloatFile(matrixB, size, secMatrixFloat);
	WriteFloatFile(matrixC, size, thrdMatrixFloat);
	WriteFloatFile(vector, size, vectorFloat);

	WriteFloatFile(res1, size, res1Float);
	WriteFloatFile(res2, size, res2Float);
	WriteFloatFile(res3, size, res3Float);
	//WriteFloatFile(pivLu, size, partialFloat);
	//WriteFloatFile(fullPivLu, size, fullFloat);
}

void WriteDoubleFile(MatrixXd doubleMatrix, int size, ofstream &file)
{
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			file << setprecision(16) << doubleMatrix(i, j);
			file << " ";
		}
		file << "\n";
	}
}

void WriteDoubleFile(VectorXd doubleVector, int size, ofstream &file)
{
	for (int i = 0; i < size; i++)
	{
		file << setprecision(16) << doubleVector(i);
		file << " ";
	}
	file << "\n";
}

void WriteFloatFile(MatrixXf matrix, int size, ofstream &file)
{
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			file << setprecision(8) << matrix(i, j);
			file << " ";
		}
		file << "\n";
	}
}

void WriteFloatFile(VectorXf vector, int size, ofstream &file)
{
	for (int i = 0; i < size; i++)
	{
		file << setprecision(16) << vector(i);
		file << " ";
	}
	file << "\n";
}


#include "stdafx.h"
#include <iostream>
#include <sstream>
#include <fstream>
#include <iomanip>
#include <vector>
#include <boost/algorithm/string/split.hpp>
#include <boost/algorithm/string/classification.hpp>
#include <Eigen/Dense>

using Eigen::MatrixXd;
using Eigen::MatrixXf;
using Eigen::VectorXd;
using Eigen::VectorXf;
using namespace std;

ifstream firstMatrixDouble;
ifstream secMatrixDouble;
ifstream thrdMatrixDouble;
ifstream vectorDouble;
ofstream res1Double;
ofstream res2Double;
ofstream res3Double;
ofstream partialDouble;
ofstream fullDouble;

ifstream firstMatrixFloat;
ifstream secMatrixFloat;
ifstream thrdMatrixFloat;
ifstream vectorFloat;
ofstream res1Float;
ofstream res2Float;
ofstream res3Float;
ofstream partialFloat;
ofstream fullFloat;

void CreateFillMatrixAndWriteToFileDouble(int size);
void WriteDoubleFile(MatrixXd doubleMatrix, int size, ofstream &file);
void WriteDoubleFile(VectorXd doubleVector, int size, ofstream &file);
MatrixXd ReadMatrixFromFileDouble(int size, ifstream &file);
VectorXd ReadVectorFromFileDouble(int size, ifstream &file);


void CreateFillMatrixAndWriteToFileFloat(int size);
void WriteFloatFile(MatrixXf matrix, int size, ofstream &file);
void WriteFloatFile(VectorXf vector, int size, ofstream &file);
MatrixXf ReadMatrixFromFileFloat(int size, ifstream &file);
VectorXf ReadVectorFromFileFloat(int size, ifstream &file);

int main(int argc, char** argv)
{
	firstMatrixDouble.open("../Output/FirstMatrixDataFraction.txt");
	secMatrixDouble.open("../Output/SecondMatrixDataFraction.txt");
	thrdMatrixDouble.open("../Output/ThirdMatrixDataFraction.txt");
	vectorDouble.open("../Output/VectorDataFraction.txt");
	res1Double.open("../Output/Res1DataDoubleCpp.txt");
	res2Double.open("../Output/Res2DataDoubleCpp.txt");
	res3Double.open("../Output/Res3DataDoubleCpp.txt");
	partialDouble.open("../Output/PartialDataDoubleCpp.txt");
	fullDouble.open("../Output/FullDataDoubleCpp.txt");

	firstMatrixFloat.open("../Output/FirstMatrixDataFloat.txt");
	secMatrixFloat.open("../Output/SecondMatrixDataFloat.txt");
	thrdMatrixFloat.open("../Output/ThirdMatrixDataFloat.txt");
	vectorFloat.open("../Output/VectorDataFloat.txt");
	res1Float.open("../Output/Res1DataFloatCpp.txt");
	res2Float.open("../Output/Res2DataFloatCpp.txt");
	res3Float.open("../Output/Res3DataFloatCpp.txt");
	partialFloat.open("../Output/PartialDataFloatCpp.txt");
	fullFloat.open("../Output/FullDataFloatCpp.txt");

	int multiplier = 2;
	int range = 5;

	for (int i = multiplier; i < range; i += multiplier)
	{
		CreateFillMatrixAndWriteToFileDouble(i);
		cout << "double ok" << endl;
		CreateFillMatrixAndWriteToFileFloat(i);
		cout << "float ok" << endl;
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
	MatrixXd matrixA = ReadMatrixFromFileDouble(size, firstMatrixDouble);
	MatrixXd matrixB = ReadMatrixFromFileDouble(size, secMatrixDouble);
	MatrixXd matrixC = ReadMatrixFromFileDouble(size, thrdMatrixDouble);
	VectorXd vector = ReadVectorFromFileDouble(size, vectorDouble);

	VectorXd res1 = matrixA * vector;
	VectorXd res2 = (matrixA + matrixB + matrixC) * vector;
	MatrixXd res3 = matrixA * (matrixB * matrixC);
	VectorXd pivLu = matrixA.lu().solve(vector);
	VectorXd fullPivLu = matrixA.fullPivLu().solve(vector);


	WriteDoubleFile(res1, size, res1Double);
	WriteDoubleFile(res2, size, res2Double);
	WriteDoubleFile(res3, size, res3Double);
	WriteDoubleFile(pivLu, size, partialDouble);
	WriteDoubleFile(fullPivLu, size, fullDouble);
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
	MatrixXf pivLu = matrixA.lu().solve(vector);
	MatrixXf fullPivLu = matrixA.fullPivLu().solve(vector);

	WriteFloatFile(res1, size, res1Float);
	WriteFloatFile(res2, size, res2Float);
	WriteFloatFile(res3, size, res3Float);
	WriteFloatFile(pivLu, size, partialFloat);
	WriteFloatFile(fullPivLu, size, fullFloat);
}

MatrixXd ReadMatrixFromFileDouble(int size, ifstream &file)
{
	MatrixXd matrix(size, size);
	string line;
	getline(file, line);
	vector<string> items;
	boost::algorithm::split(items, line, boost::algorithm::is_any_of(" "));
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			int splitNumber = size * i + j;
			matrix(i, j) = atof(items[splitNumber].c_str());
		}
	}
	return matrix;
}

MatrixXf ReadMatrixFromFileFloat(int size, ifstream &file)
{
	MatrixXf matrix(size, size);
	string line;
	getline(file, line);
	vector<string> items;
	boost::algorithm::split(items, line, boost::algorithm::is_any_of(" "));

	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			int splitNumber = size * i + j;
			matrix(i, j) = (float)atof(items[splitNumber].c_str());
		}
	}
	return matrix;
}
VectorXd ReadVectorFromFileDouble(int size, ifstream &file)
{
	VectorXd vec(size);
	string line;
	getline(file, line);
	vector<string> items;
	boost::algorithm::split(items, line, boost::algorithm::is_any_of(" "));


	for (int i = 0; i < size; i++)
	{
		vec(i) = atof(items[i].c_str());
	}
	return vec;
}
VectorXf ReadVectorFromFileFloat(int size, ifstream &file)
{
	VectorXf vec(size);
	string line;
	getline(file, line);
	vector<string> items;
	boost::algorithm::split(items, line, boost::algorithm::is_any_of(" "));

	for (int i = 0; i < size; i++)
	{
		vec(i) = (float)atof(items[i].c_str());
	}
	return vec;
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
	}
	file << "\n";
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


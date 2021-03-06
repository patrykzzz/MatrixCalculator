#include "stdafx.h"
#include <iostream>
#include <sstream>
#include <fstream>
#include <iomanip>
#include <vector>
#include <ctime>
#include <chrono>
#include <windows.h>
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

ofstream timeDouble;
ofstream timeFloat;

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

void WriteTimeToFile(string time, ofstream &file);

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

	timeFloat.open("../Output/TimeFloatCpp.txt");
	timeDouble.open("../Output/TimeDoubleCpp.txt");

	int multiplier = 5;
	int range = 101;

	for (int i = multiplier; i < range; i += multiplier)
	{
		cout << "Iteracja - " << i << endl;
		CreateFillMatrixAndWriteToFileDouble(i);
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

	firstMatrixFloat.open("../Output/FirstMatrixDataFraction.txt");
	secMatrixFloat.open("../Output/SecondMatrixDataFraction.txt");
	thrdMatrixFloat.open("../Output/ThirdMatrixDataFraction.txt");
	vectorFloat.open("../Output/VectorDataFraction.txt");
	res1Float.open("../Output/Res1DataFloatCpp.txt");
	res2Float.open("../Output/Res2DataFloatCpp.txt");
	res3Float.open("../Output/Res3DataFloatCpp.txt");
	partialFloat.open("../Output/PartialDataFloatCpp.txt");
	fullFloat.open("../Output/FullDataFloatCpp.txt");

	for (int i = multiplier; i < range; i += multiplier)
	{
		cout << "Iteracja - " << i << endl;
		CreateFillMatrixAndWriteToFileFloat(i);
	}

	firstMatrixFloat.close();
	secMatrixFloat.close();
	thrdMatrixFloat.close();
	vectorFloat.close();
	res1Float.close();
	res2Float.close();
	res3Float.close();
	partialFloat.close();
	fullFloat.close();

	timeFloat.close();
	timeDouble.close();

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

	auto start = std::chrono::high_resolution_clock::now();
	VectorXd res1 = matrixA * vector;
	auto finish = std::chrono::high_resolution_clock::now();
	double res1Time = std::chrono::duration_cast<std::chrono::nanoseconds>(finish - start).count();

	start = std::chrono::high_resolution_clock::now();
	VectorXd res2 = (matrixA + matrixB + matrixC) * vector;
	finish = std::chrono::high_resolution_clock::now();
	double res2Time = std::chrono::duration_cast<std::chrono::nanoseconds>(finish - start).count();

	start = std::chrono::high_resolution_clock::now();
	MatrixXd res3 = matrixA * (matrixB * matrixC);
	finish = std::chrono::high_resolution_clock::now();
	double res3Time = std::chrono::duration_cast<std::chrono::nanoseconds>(finish - start).count();

	start = std::chrono::high_resolution_clock::now();
	VectorXd pivLu = matrixA.lu().solve(vector);
	finish = std::chrono::high_resolution_clock::now();
	double pivLuTime = std::chrono::duration_cast<std::chrono::nanoseconds>(finish - start).count();

	start = std::chrono::high_resolution_clock::now();
	VectorXd fullPivLu = matrixA.fullPivLu().solve(vector);
	finish = std::chrono::high_resolution_clock::now();
	double fullTime = std::chrono::duration_cast<std::chrono::nanoseconds>(finish - start).count();

	res1Time /= 1000000;
	res2Time /= 1000000;
	res3Time /= 1000000;
	pivLuTime /= 1000000;
	fullTime /= 1000000;

	string res =  to_string(res1Time) + " " + to_string(res2Time) + ' ' + to_string(res3Time) + ' ' + to_string(pivLuTime) + ' ' + to_string(fullTime);
	//cout << res << endl;
	WriteTimeToFile(res, timeDouble);

	WriteDoubleFile(res1, size, res1Double);
	WriteDoubleFile(res2, size, res2Double);
	WriteDoubleFile(res3, size, res3Double);
	WriteDoubleFile(pivLu, size, partialDouble);
	WriteDoubleFile(fullPivLu, size, fullDouble);
}


void CreateFillMatrixAndWriteToFileFloat(int size)
{
	MatrixXf matrixA = ReadMatrixFromFileFloat(size, firstMatrixFloat);
	MatrixXf matrixB = ReadMatrixFromFileFloat(size, secMatrixFloat);
	MatrixXf matrixC = ReadMatrixFromFileFloat(size, thrdMatrixFloat);
	VectorXf vector = ReadVectorFromFileFloat(size, vectorFloat);

	auto start = std::chrono::high_resolution_clock::now();
	VectorXf res1 = matrixA * vector;
	auto finish = std::chrono::high_resolution_clock::now();
	double res1Time = std::chrono::duration_cast<std::chrono::nanoseconds>(finish - start).count();

	start = std::chrono::high_resolution_clock::now();
	VectorXf res2 = (matrixA + matrixB + matrixC) * vector;
	finish = std::chrono::high_resolution_clock::now();
	double res2Time = std::chrono::duration_cast<std::chrono::nanoseconds>(finish - start).count();

	start = std::chrono::high_resolution_clock::now();
	MatrixXf res3 = matrixA * (matrixB * matrixC);
	finish = std::chrono::high_resolution_clock::now();
	double res3Time = std::chrono::duration_cast<std::chrono::nanoseconds>(finish - start).count();

	start = std::chrono::high_resolution_clock::now();
	VectorXf pivLu = matrixA.lu().solve(vector);
	finish = std::chrono::high_resolution_clock::now();
	double pivLuTime = std::chrono::duration_cast<std::chrono::nanoseconds>(finish - start).count();

	start = std::chrono::high_resolution_clock::now();
	VectorXf fullPivLu = matrixA.fullPivLu().solve(vector);
	finish = std::chrono::high_resolution_clock::now();
	double fullTime = std::chrono::duration_cast<std::chrono::nanoseconds>(finish - start).count();

	res1Time /= 1000000;
	res2Time /= 1000000;
	res3Time /= 1000000;
	pivLuTime /= 1000000;
	fullTime /= 1000000;

	string res = to_string(res1Time) + " " + to_string(res2Time) + ' ' + to_string(res3Time) + ' ' + to_string(pivLuTime) + ' ' + to_string(fullTime);
	//cout << res << endl;

	WriteTimeToFile(res, timeFloat);

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
	}
	file << "\n";
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
		file << setprecision(8) << vector(i);
		file << " ";
	}
	file << "\n";
}

void WriteTimeToFile(string time, ofstream &file)
{
	file << time << endl;
}


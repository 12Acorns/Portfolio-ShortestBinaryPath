using System.Collections;

namespace ShortestBinaryPathApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			byte[,] _map = new byte[,]
			{
				{ 0, 1, 0 },
				{ 0, 0, 1 },
				{ 1, 0, 1 },
				{ 1, 1, 0 },
			};

			int _result = FindShortestPath(_map);
			Console.WriteLine(_result);
			Console.ReadLine();
		}

		private static int FindShortestPath(byte[,] _data)
		{
			if(_data.Length <= 0)
			{
				return -1;
			}

			int _rowLength = _data.GetLength(0);

			int _currentPathLength = 0;

			for(int i = 0; i < _data.Rank; i++)
			{
				for(int j = 0; j < _rowLength; j++)
				{
					if(_data[i, j] == 0)
					{
						if(_data[i + 1, j + 1] == 0)
						{
							_currentPathLength += 1;
							ExploreBranch(_data, _rowLength, i + 1, j + 1, ref _currentPathLength);
							break;
						}
						else if(_data[i, j + 1] == 0)
						{
							_currentPathLength += 1;
							ExploreBranch(_data, _rowLength, i, j + 1, ref _currentPathLength);
							break;
						}
						else if(_data[i + 1, j] == 0)
						{
							_currentPathLength += 1;
							ExploreBranch(_data, _rowLength, i + 1, j, ref _currentPathLength);
							break;
						}
						break;
					}
				}
			}
			return _currentPathLength > 0 ? _currentPathLength + 1 : -1;
		}

		private static void ExploreBranch(byte[,] _data, int _rowLength, int _x, int _y,
			ref int _currentBranchLength)
		{
			for(; _x < _data.Rank; _x++)
			{
				for(; _y < _rowLength; _y++)
				{
					if(_x == _data.Rank-1 && _y == _rowLength - 1)
					{
						break;
					}

					if(_data[_x, _y] == 0)
					{
						if(_data[_x + 1, _y + 1] == 0)
						{
							_currentBranchLength += 1;
							ExploreBranch(_data, _rowLength, _x + 1, _y + 1, ref _currentBranchLength);
							continue;
						}
						else if(_data[_x + 1, _y] == 0)
						{
							_currentBranchLength += 1;
							ExploreBranch(_data, _rowLength, _x + 1, _y, ref _currentBranchLength);
							continue;
						}
						else if(_data[_x, _y + 1] == 0)
						{
							_currentBranchLength += 1;
							ExploreBranch(_data, _rowLength, _x, _y + 1, ref _currentBranchLength);
							continue;
						}
						_currentBranchLength = 0;
					}
				}
			}
		}
	}
}
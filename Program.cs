using System;
using System.Collections.Generic;

class ONElabInterview
{
    public static List<List<string>> GetAnswers(int n){
        var answers = new List<List<string>>();
        var state = new int[n];
        TestRecursion(state, 0, answers);
        return answers;
    }
    private static void TestRecursion(int[] state, int row, List<List<string>> answers){
        if (row == state.Length){
            answers.Add(GenerateBoard(state));
            return;
        }
        for(int col = 0; col < state.Length; col++){
            if(IsValid(state, row, col)){
                state[row] = col;
                TestRecursion(state, row + 1, answers);
            }
        }
    }
    private static bool IsValid(int[] state, int row, int col){
        for (int i = 0; i < row; i++){
            if(state[i] == col || state[i]-i == col - row || state[i]+i == col + row){
                return false;
            }
        }
        return true;
    }
    private static List<string> GenerateBoard(int[] state){
        var res = new List<string>();
        for (int i = 0; i < state.Length; i++){
            var row = new char[state.Length];
            for (int j = 0; j < state.Length; j++){
                if(state[i] == j){
                    row[j] = 'Q';
                }else{
                    row[j] = '.';
                }
            }
            res.Add(new string(row));
        }
        return res;
    }
    static void Main(string[] args)
    {
        var answers = GetAnswers(8);
        Console.WriteLine($"Total solutions:{answers.Count}");
        foreach(var answer in answers){
            Console.WriteLine("Solition:");
            foreach(var row in answer){
                Console.WriteLine(row);
            }
        }
        Console.WriteLine();
    }
}

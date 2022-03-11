using System;

namespace Unit1Assignment
{
    class Driver
    {
        #region Exercise 1.1
        /*
         Exercise 1.1)

        10 
        -> 10

        (+ 5 3 4)
        -> 12

        (- 9 1)
        -> 8

        (/ 6 2)
        -> 3

        (+ (* 2 4) (- 4 6))
        -> 6

        (define a 3) (define b (+ a 1))
        (+ a b (* a b))
        -> 19

        (= a b)
        -> F

        (if (and (> b a) (< b (* a b)))
            b 
            a)
        -> 4

        (cond ((= a 4) 6)
            ((= b 4) (+ 6 7 a))
            (else 25))
        -> 16

        (+ 2 (if (> b a) b a))
        -> 6

        (* (cond ((> a b) a)
            ((< a b) b)
            (else -1))
                (+ a 1))
        -> 16

        */
        #endregion



        #region Exercise 1.3
        //Define a procedure that takes three numbers as arguments and returns the sum of the squares of the two larger numbers
        public static int SumOfLargerSquares(int a, int b, int c)
        {
            if ((a <= b) && (a <= c)) return (b * b) + (c * c);
            if ((b <= a) && (b <= c)) return (a * a) + (c * c);
            return (a * a) + (b * b);
        }
        #endregion



        #region Exercise 1.6
        //What happens when Alyssa atempts to use this to compute square roots? Explain.

        /*
        Alyssa's implementation of new-if will introduce an error. The built in 'if' and 'cond' are special forms which will only 
        be evaluated one at a time. The book states, 
        
        "To evaluate an if expression, the interpreter starts by evaluating the
        ⟨predicate⟩ part of the expression. If the ⟨predicate⟩ evaluates to a true
        value, the interpreter then evaluates the ⟨consequent⟩ and returns its
        value. Otherwise it evaluates the ⟨alternative⟩ and returns its value" - page 24

        A procedure, such as the 'new-if' that Alyssa has created, has its arguments evaluated
        prior to running the procedure as it follows 'applicative-order evaluation' The book reads, 
        
        "the interpreter first evaluates the operator and operands and then applies
        the resulting procedure to the resulting arguments" - page 20
        
        Ultimately, the special form of if/cond allows sqrt-iter to be written, whereas the 
        home made procedure of 'new-if' will never resolve to a value because one of the operators/operands are
        calling srt-iter recursively and cannot be evaluated.
        */
        #endregion



        #region Exercise 1.8
        public static double GetCubeRoot(int value)
        {
            double currGuess = 1;
            while(!WithinMarginOfError(currGuess, value))
            {
                currGuess = NewtonCubeFormula(value, currGuess);
            }
            return currGuess;
        }

        private static double NewtonCubeFormula(double x, double y)
        {
            return ((x / (y * y)) + (2 * y)) / 3;
        }

        private static bool WithinMarginOfError(double guess, double value)
        {
            if (Math.Abs((guess * guess * guess) - value) < .001) return true;
            return false;
        }
        #endregion



        public static void Main(string[] args)
        {
            Console.WriteLine(SumOfLargerSquares(3, 4, 5) + "\n\n");
            Console.WriteLine(GetCubeRoot(28));
        }
    }
}
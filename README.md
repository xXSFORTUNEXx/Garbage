# Garbage
Farkle mixed with yahtzee where you may get something you think is good, but its actual garbage.

Rules:<br>
On the first turn you roll all 6 dice.
You must get a One, Five or any Combination listed.
If you roll all 6 into One, Five or some of the many Combinations you have Hot Dice and can start over rolling all 6.
You will then add the total from before Hot Dice to the new roll. You can roll until you want to stop unless you<br>
do not roll a One, Five or a Combination. You can then choose to take a Chance or take a 0. If you take a Chance and fail you will be
deducted 500 points. If you succeeded then you continue until you choose to stop or fail and take another Chance or take a 0.
If you fail another Chance you are deducted 500 points multiplied by the amount of successful Chances.

Combinations:<br>
3 x Twos - 200 Points<br>
Straight One-Two-Three - 250 Points<br>
3 x Threes - 300 Points<br>
3 x Fours - 400 Points<br>
3 x Fives - 500 Points<br>
2 Pairs of Any 2 Numbers - 500 Points<br>
Straight One-Two-Three-Four - 500 Points<br>
3 x Sixes - 600 Points<br>
3 x Ones - 1000 Points<br>
4 Set Any Number - 1000 Points<br>
Full House Set Of 3 and 2 Pair - 1000 Points<br>
Straight One-Two-Three-Four-Five - 1000 Points<br>
5 Set Any Number - 2000 Points<br>
3 Set and 3 Set Any Number - 2000 Points<br>
3 Pairs of 2 Any Number - 2000 Points<br>
Straight One-Two-Three-Four-Five-Six - 3000 Points<br>
6 Set Any Number - 3000 Points<br>
4 Set Any Number And 2 Pair Any Number - 3000 Points<br>
1 Pair Any Number - 50 Points<br>
One - 100 Points<br>
Five - 50 Points<br>

Special Rules:
Chances - Chances allow you to continue when you've rolled nothing. If you successfully roll a One, Five or Combination you continue 
and add the result to your total. Each chance you take multiples the amount of points lost if the next chance is unsuccessful. Use them
wisely.

Hot Dice - When you roll all 6 into a One, Five or Combination you can pickup all 6 and roll them again. You now add the total from the last
roll to the new roll and continue on until you get Hot Dice again, take a chance or take a 0.

Adds - Each game you are alloted 2 adds. This allows you to create a combination from individually rolled dice. For example, if you roll 
6 Ones in 6 different turns you can use an add to make it a combination of 6 Set Any Number and claim 3000 points instead of 600. After 
using an add you must end your turn and take the total you rolled. You may use 1 add from the beginning and the second after the halfway
mark of the game. You cannot use both in the same quarter.

Dice combinations are examined in the code going from left to right, the top-left die being number 1 and the bottom-left die being number 4.
Example: 
1-2-3
4-5-6

Combinations are checked in descending order starting with the first you have checked. Because of this when you sometimes select 1 Pair any
number and a single one it will only claim that pair of ones due to it being first in the priority check. This is still a work in progress
so once the list is better prioritized this wont occur much if at all.
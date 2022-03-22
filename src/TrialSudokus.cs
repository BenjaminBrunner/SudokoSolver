using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver
{
    public partial class SudokuTable
    {
        private void FillSudokuTable_5()
        {
            for (int i = 0; i < SudokuFieldsLength; i++)
            {
                SudokuFields[i] = new SudokuField();
            }

            SudokuFields[0].SolveSudokoField();
            SudokuFields[1].SolveSudokoField();
            SudokuFields[2].SolveSudokoField();
            SudokuFields[3].SolveSudokoField(1);
            SudokuFields[4].SolveSudokoField();
            SudokuFields[5].SolveSudokoField();
            SudokuFields[6].SolveSudokoField(2);
            SudokuFields[7].SolveSudokoField();
            SudokuFields[8].SolveSudokoField();

            SudokuFields[9].SolveSudokoField();
            SudokuFields[10].SolveSudokoField();
            SudokuFields[11].SolveSudokoField();
            SudokuFields[12].SolveSudokoField();
            SudokuFields[13].SolveSudokoField(7);
            SudokuFields[14].SolveSudokoField(8);
            SudokuFields[15].SolveSudokoField(1);
            SudokuFields[16].SolveSudokoField();
            SudokuFields[17].SolveSudokoField();

            SudokuFields[18].SolveSudokoField();
            SudokuFields[19].SolveSudokoField();
            SudokuFields[20].SolveSudokoField();
            SudokuFields[21].SolveSudokoField();
            SudokuFields[22].SolveSudokoField();
            SudokuFields[23].SolveSudokoField();
            SudokuFields[24].SolveSudokoField();
            SudokuFields[25].SolveSudokoField(5);
            SudokuFields[26].SolveSudokoField(7);

            SudokuFields[27].SolveSudokoField();
            SudokuFields[28].SolveSudokoField(2);
            SudokuFields[29].SolveSudokoField(8);
            SudokuFields[30].SolveSudokoField();
            SudokuFields[31].SolveSudokoField(9);
            SudokuFields[32].SolveSudokoField();
            SudokuFields[33].SolveSudokoField(7);
            SudokuFields[34].SolveSudokoField();
            SudokuFields[35].SolveSudokoField();

            SudokuFields[36].SolveSudokoField();
            SudokuFields[37].SolveSudokoField(3);
            SudokuFields[38].SolveSudokoField();
            SudokuFields[39].SolveSudokoField(8);
            SudokuFields[40].SolveSudokoField();
            SudokuFields[41].SolveSudokoField(2);
            SudokuFields[42].SolveSudokoField();
            SudokuFields[43].SolveSudokoField(4);
            SudokuFields[44].SolveSudokoField();

            SudokuFields[45].SolveSudokoField();
            SudokuFields[46].SolveSudokoField();
            SudokuFields[47].SolveSudokoField(6);
            SudokuFields[48].SolveSudokoField();
            SudokuFields[49].SolveSudokoField(1);
            SudokuFields[50].SolveSudokoField();
            SudokuFields[51].SolveSudokoField(5);
            SudokuFields[52].SolveSudokoField(8);
            SudokuFields[53].SolveSudokoField();

            SudokuFields[54].SolveSudokoField(1);
            SudokuFields[55].SolveSudokoField(6);
            SudokuFields[56].SolveSudokoField();
            SudokuFields[57].SolveSudokoField();
            SudokuFields[58].SolveSudokoField();
            SudokuFields[59].SolveSudokoField();
            SudokuFields[60].SolveSudokoField();
            SudokuFields[61].SolveSudokoField();
            SudokuFields[62].SolveSudokoField();

            SudokuFields[63].SolveSudokoField();
            SudokuFields[64].SolveSudokoField();
            SudokuFields[65].SolveSudokoField(2);
            SudokuFields[66].SolveSudokoField(9);
            SudokuFields[67].SolveSudokoField(3);
            SudokuFields[68].SolveSudokoField();
            SudokuFields[69].SolveSudokoField();
            SudokuFields[70].SolveSudokoField();
            SudokuFields[71].SolveSudokoField();

            SudokuFields[72].SolveSudokoField();
            SudokuFields[73].SolveSudokoField();
            SudokuFields[74].SolveSudokoField(3);
            SudokuFields[75].SolveSudokoField();
            SudokuFields[76].SolveSudokoField();
            SudokuFields[77].SolveSudokoField(7);
            SudokuFields[78].SolveSudokoField();
            SudokuFields[79].SolveSudokoField();
            SudokuFields[80].SolveSudokoField();
        }

        private void FillSudokuTable_4()
        {
            for (int i = 0; i < SudokuFieldsLength; i++)
            {
                SudokuFields[i] = new SudokuField();
            }

            SudokuFields[0].SolveSudokoField();
            SudokuFields[1].SolveSudokoField();
            SudokuFields[2].SolveSudokoField(3);
            SudokuFields[3].SolveSudokoField();
            SudokuFields[4].SolveSudokoField(6);
            SudokuFields[5].SolveSudokoField(7);
            SudokuFields[6].SolveSudokoField();
            SudokuFields[7].SolveSudokoField();
            SudokuFields[8].SolveSudokoField(8);

            SudokuFields[9].SolveSudokoField(9);
            SudokuFields[10].SolveSudokoField(6);
            SudokuFields[11].SolveSudokoField();
            SudokuFields[12].SolveSudokoField();
            SudokuFields[13].SolveSudokoField();
            SudokuFields[14].SolveSudokoField();
            SudokuFields[15].SolveSudokoField();
            SudokuFields[16].SolveSudokoField();
            SudokuFields[17].SolveSudokoField(7);

            SudokuFields[18].SolveSudokoField(4);
            SudokuFields[19].SolveSudokoField();
            SudokuFields[20].SolveSudokoField();
            SudokuFields[21].SolveSudokoField();
            SudokuFields[22].SolveSudokoField(9);
            SudokuFields[23].SolveSudokoField();
            SudokuFields[24].SolveSudokoField();
            SudokuFields[25].SolveSudokoField();
            SudokuFields[26].SolveSudokoField();

            SudokuFields[27].SolveSudokoField(7);
            SudokuFields[28].SolveSudokoField(1);
            SudokuFields[29].SolveSudokoField();
            SudokuFields[30].SolveSudokoField(3);
            SudokuFields[31].SolveSudokoField();
            SudokuFields[32].SolveSudokoField();
            SudokuFields[33].SolveSudokoField();
            SudokuFields[34].SolveSudokoField();
            SudokuFields[35].SolveSudokoField();

            SudokuFields[36].SolveSudokoField();
            SudokuFields[37].SolveSudokoField(2);
            SudokuFields[38].SolveSudokoField();
            SudokuFields[39].SolveSudokoField();
            SudokuFields[40].SolveSudokoField();
            SudokuFields[41].SolveSudokoField();
            SudokuFields[42].SolveSudokoField();
            SudokuFields[43].SolveSudokoField(3);
            SudokuFields[44].SolveSudokoField();

            SudokuFields[45].SolveSudokoField();
            SudokuFields[46].SolveSudokoField();
            SudokuFields[47].SolveSudokoField();
            SudokuFields[48].SolveSudokoField();
            SudokuFields[49].SolveSudokoField();
            SudokuFields[50].SolveSudokoField(2);
            SudokuFields[51].SolveSudokoField();
            SudokuFields[52].SolveSudokoField(4);
            SudokuFields[53].SolveSudokoField(1);

            SudokuFields[54].SolveSudokoField();
            SudokuFields[55].SolveSudokoField();
            SudokuFields[56].SolveSudokoField();
            SudokuFields[57].SolveSudokoField();
            SudokuFields[58].SolveSudokoField(8);
            SudokuFields[59].SolveSudokoField();
            SudokuFields[60].SolveSudokoField();
            SudokuFields[61].SolveSudokoField();
            SudokuFields[62].SolveSudokoField(6);

            SudokuFields[63].SolveSudokoField(8);
            SudokuFields[64].SolveSudokoField();
            SudokuFields[65].SolveSudokoField();
            SudokuFields[66].SolveSudokoField();
            SudokuFields[67].SolveSudokoField();
            SudokuFields[68].SolveSudokoField();
            SudokuFields[69].SolveSudokoField();
            SudokuFields[70].SolveSudokoField(1);
            SudokuFields[71].SolveSudokoField(5);

            SudokuFields[72].SolveSudokoField(3);
            SudokuFields[73].SolveSudokoField();
            SudokuFields[74].SolveSudokoField();
            SudokuFields[75].SolveSudokoField(5);
            SudokuFields[76].SolveSudokoField(7);
            SudokuFields[77].SolveSudokoField();
            SudokuFields[78].SolveSudokoField(8);
            SudokuFields[79].SolveSudokoField();
            SudokuFields[80].SolveSudokoField();

        }

        private void FillSudokuTable_2()
        {
            for (int i = 0; i < SudokuFieldsLength; i++)
            {
                SudokuFields[i] = new SudokuField();
            }

            SudokuFields[3].SolveSudokoField(4);
            SudokuFields[6].SolveSudokoField(1);
            SudokuFields[9].SolveSudokoField(6);
            SudokuFields[18].SolveSudokoField(2);
            SudokuFields[19].SolveSudokoField(5);
            SudokuFields[22].SolveSudokoField(7);
            SudokuFields[25].SolveSudokoField(4);
            SudokuFields[29].SolveSudokoField(9);
            SudokuFields[41].SolveSudokoField(3);
            SudokuFields[44].SolveSudokoField(8);
            SudokuFields[45].SolveSudokoField(4);
            SudokuFields[46].SolveSudokoField(7);
            SudokuFields[49].SolveSudokoField(2);
            SudokuFields[52].SolveSudokoField(1);
            SudokuFields[56].SolveSudokoField(1);
            SudokuFields[58].SolveSudokoField(9);
            SudokuFields[63].SolveSudokoField(5);
            SudokuFields[64].SolveSudokoField(9);
            SudokuFields[68].SolveSudokoField(2);
            SudokuFields[69].SolveSudokoField(3);
            SudokuFields[74].SolveSudokoField(6);
            SudokuFields[79].SolveSudokoField(5);


        }

        private void FillSudokuTable_3()
        {
            for (int i = 0; i < SudokuFieldsLength; i++)
            {
                SudokuFields[i] = new SudokuField();
            }

            SudokuFields[0].SolveSudokoField();
            SudokuFields[1].SolveSudokoField();
            SudokuFields[2].SolveSudokoField();
            SudokuFields[3].SolveSudokoField();
            SudokuFields[4].SolveSudokoField();
            SudokuFields[5].SolveSudokoField(6);
            SudokuFields[6].SolveSudokoField();
            SudokuFields[7].SolveSudokoField();
            SudokuFields[8].SolveSudokoField(7);

            SudokuFields[9].SolveSudokoField();
            SudokuFields[10].SolveSudokoField();
            SudokuFields[11].SolveSudokoField();
            SudokuFields[12].SolveSudokoField(2);
            SudokuFields[13].SolveSudokoField(3);
            SudokuFields[14].SolveSudokoField();
            SudokuFields[15].SolveSudokoField(4);
            SudokuFields[16].SolveSudokoField(9);
            SudokuFields[17].SolveSudokoField();

            SudokuFields[18].SolveSudokoField(9);
            SudokuFields[19].SolveSudokoField();
            SudokuFields[20].SolveSudokoField(7);
            SudokuFields[21].SolveSudokoField();
            SudokuFields[22].SolveSudokoField();
            SudokuFields[23].SolveSudokoField();
            SudokuFields[24].SolveSudokoField();
            SudokuFields[25].SolveSudokoField();
            SudokuFields[26].SolveSudokoField(8);

            SudokuFields[27].SolveSudokoField();
            SudokuFields[28].SolveSudokoField();
            SudokuFields[29].SolveSudokoField(8);
            SudokuFields[30].SolveSudokoField();
            SudokuFields[31].SolveSudokoField(1);
            SudokuFields[32].SolveSudokoField();
            SudokuFields[33].SolveSudokoField(7);
            SudokuFields[34].SolveSudokoField();
            SudokuFields[35].SolveSudokoField(4);

            SudokuFields[36].SolveSudokoField();
            SudokuFields[37].SolveSudokoField(3);
            SudokuFields[38].SolveSudokoField();
            SudokuFields[39].SolveSudokoField();
            SudokuFields[40].SolveSudokoField();
            SudokuFields[41].SolveSudokoField();
            SudokuFields[42].SolveSudokoField();
            SudokuFields[43].SolveSudokoField(1);
            SudokuFields[44].SolveSudokoField();

            SudokuFields[45].SolveSudokoField(2);
            SudokuFields[46].SolveSudokoField();
            SudokuFields[47].SolveSudokoField(1);
            SudokuFields[48].SolveSudokoField();
            SudokuFields[49].SolveSudokoField(5);
            SudokuFields[50].SolveSudokoField();
            SudokuFields[51].SolveSudokoField(8);
            SudokuFields[52].SolveSudokoField();
            SudokuFields[53].SolveSudokoField();

            SudokuFields[54].SolveSudokoField(8);
            SudokuFields[55].SolveSudokoField();
            SudokuFields[56].SolveSudokoField();
            SudokuFields[57].SolveSudokoField();
            SudokuFields[58].SolveSudokoField();
            SudokuFields[59].SolveSudokoField();
            SudokuFields[60].SolveSudokoField(1);
            SudokuFields[61].SolveSudokoField();
            SudokuFields[62].SolveSudokoField(6);

            SudokuFields[63].SolveSudokoField();
            SudokuFields[64].SolveSudokoField(9);
            SudokuFields[65].SolveSudokoField(6);
            SudokuFields[66].SolveSudokoField();
            SudokuFields[67].SolveSudokoField(7);
            SudokuFields[68].SolveSudokoField(8);
            SudokuFields[69].SolveSudokoField();
            SudokuFields[70].SolveSudokoField();
            SudokuFields[71].SolveSudokoField();

            SudokuFields[72].SolveSudokoField(7);
            SudokuFields[73].SolveSudokoField();
            SudokuFields[74].SolveSudokoField();
            SudokuFields[75].SolveSudokoField(1);
            SudokuFields[76].SolveSudokoField();
            SudokuFields[77].SolveSudokoField();
            SudokuFields[78].SolveSudokoField();
            SudokuFields[79].SolveSudokoField();
            SudokuFields[80].SolveSudokoField();


        }

        private void FillSudokuTable_1()
        {
            for (int i = 0; i < SudokuFieldsLength; i++)
            {
                SudokuFields[i] = new SudokuField();
            }

            //SudukoFields[0].SolveSudokoField();
            //SudukoFields[1].SolveSudokoField();
            SudokuFields[2].SolveSudokoField(6);
            SudokuFields[3].SolveSudokoField(7);
            SudokuFields[4].SolveSudokoField(4);
            SudokuFields[5].SolveSudokoField(5);
            SudokuFields[6].SolveSudokoField(1);
            SudokuFields[7].SolveSudokoField(2);
            //SudukoFields[8].SolveSudokoField();
            //SudukoFields[9].SolveSudokoField();
            SudokuFields[10].SolveSudokoField(8);
            //SudukoFields[11].SolveSudokoField();
            SudokuFields[12].SolveSudokoField(1);
            SudokuFields[13].SolveSudokoField(9);
            //SudukoFields[14].SolveSudokoField();
            //SudukoFields[15].SolveSudokoField();
            SudokuFields[16].SolveSudokoField(7);
            //SudukoFields[17].SolveSudokoField();
            //SudukoFields[18].SolveSudokoField();
            //SudukoFields[19].SolveSudokoField();
            //SudukoFields[20].SolveSudokoField();
            //SudukoFields[21].SolveSudokoField();
            SudokuFields[22].SolveSudokoField(3);
            SudokuFields[23].SolveSudokoField(2);
            //SudukoFields[24].SolveSudokoField();
            SudokuFields[25].SolveSudokoField(4);
            SudokuFields[26].SolveSudokoField(6);
            SudokuFields[27].SolveSudokoField(6);
            //SudukoFields[28].SolveSudokoField();
            //SudukoFields[29].SolveSudokoField();
            //SudukoFields[30].SolveSudokoField();
            SudokuFields[31].SolveSudokoField(8);
            SudokuFields[32].SolveSudokoField(4);
            //SudukoFields[33].SolveSudokoField();
            //SudukoFields[34].SolveSudokoField();
            //SudukoFields[35].SolveSudokoField();
            SudokuFields[36].SolveSudokoField(8);
            SudokuFields[37].SolveSudokoField(3);
            SudokuFields[38].SolveSudokoField(1);
            //SudukoFields[39].SolveSudokoField();
            //SudukoFields[40].SolveSudokoField();
            //SudukoFields[41].SolveSudokoField();
            SudokuFields[42].SolveSudokoField(4);
            //SudukoFields[43].SolveSudokoField();
            //SudukoFields[44].SolveSudokoField();
            //SudukoFields[45].SolveSudokoField();
            SudokuFields[46].SolveSudokoField(4);
            SudokuFields[47].SolveSudokoField(9);
            SudokuFields[48].SolveSudokoField(6);
            //SudukoFields[49].SolveSudokoField();
            SudokuFields[50].SolveSudokoField(3);
            SudokuFields[51].SolveSudokoField(2);
            //SudukoFields[52].SolveSudokoField();
            SudokuFields[53].SolveSudokoField(7);
            //SudukoFields[54].SolveSudokoField();
            //SudukoFields[55].SolveSudokoField();
            SudokuFields[56].SolveSudokoField(5);
            //SudukoFields[57].SolveSudokoField();
            SudokuFields[58].SolveSudokoField(7);
            SudokuFields[59].SolveSudokoField(8);
            //SudukoFields[60].SolveSudokoField();
            SudokuFields[61].SolveSudokoField(9);
            //SudukoFields[62].SolveSudokoField();
            SudokuFields[63].SolveSudokoField(9);
            SudokuFields[64].SolveSudokoField(2);
            //SudukoFields[65].SolveSudokoField();
            //SudukoFields[66].SolveSudokoField();
            //SudukoFields[67].SolveSudokoField();
            SudokuFields[68].SolveSudokoField(1);
            //SudukoFields[69].SolveSudokoField();
            //SudukoFields[70].SolveSudokoField();
            //SudukoFields[71].SolveSudokoField();
            SudokuFields[72].SolveSudokoField(7);
            //SudukoFields[73].SolveSudokoField();
            SudokuFields[74].SolveSudokoField(3);
            //SudukoFields[75].SolveSudokoField();
            //SudukoFields[76].SolveSudokoField();
            //SudukoFields[77].SolveSudokoField();
            SudokuFields[78].SolveSudokoField(8);
            //SudukoFields[79].SolveSudokoField();
            SudokuFields[80].SolveSudokoField(5);



        }

        private void FillSudokuTable_6()
        {
            for (int i = 0; i < SudokuFieldsLength; i++)
            {
                SudokuFields[i] = new SudokuField();
            }
            SudokuFields[0].SolveSudokoField(8);
            SudokuFields[11].SolveSudokoField(3);
            SudokuFields[12].SolveSudokoField(6);
            SudokuFields[19].SolveSudokoField(7);
            SudokuFields[22].SolveSudokoField(9);
            SudokuFields[24].SolveSudokoField(2);
            SudokuFields[28].SolveSudokoField(5);
            SudokuFields[32].SolveSudokoField(7);
            SudokuFields[40].SolveSudokoField(4);
            SudokuFields[41].SolveSudokoField(5);
            SudokuFields[42].SolveSudokoField(7);
            SudokuFields[48].SolveSudokoField(1);
            SudokuFields[51].SolveSudokoField(3);
            SudokuFields[56].SolveSudokoField(1);
            SudokuFields[61].SolveSudokoField(6);
            SudokuFields[62].SolveSudokoField(8);
            SudokuFields[65].SolveSudokoField(8);
            SudokuFields[66].SolveSudokoField(5);
            SudokuFields[70].SolveSudokoField(1);
            SudokuFields[73].SolveSudokoField(9);
            SudokuFields[78].SolveSudokoField(4);

        }

    }
}

using dcom.controllers.controllers_middleware;
using dcom.declaration;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dcom.models.models_testcaseHandling
{
    class Model_PushTestcaseService2E
    {
        public static int rowIndex;
        public static void PushTestcaseService2E(Worksheet ws, int startRowIndex, bool selectedStatus)
        {
            if (selectedStatus)
            {
                rowIndex = startRowIndex;

                TestGroupComponent(ws, rowIndex);
                AllowSessionComponent(ws, rowIndex);
                AddressingModeComponent(ws, rowIndex);
                SuppressBitComponent(ws, rowIndex);
                DIDComponent(ws, rowIndex);
                ConditionCheckComponent(ws, rowIndex);
                NRCComponent(ws, rowIndex);

                // return a current ID
                declaration.TestcaseVariables.ID = rowIndex;
            }
            
        }

        public static void TestGroupComponent(Worksheet ws, int startRowIndex)
        {
            ws.Cells[startRowIndex, TestcaseVariables.IDColumnIndex] = TestcaseVariables.SubID + rowIndex;
            ws.Cells[startRowIndex, TestcaseVariables.ComponentColumnIndex] = Controller_ServiceHandling.GetServiceTestGroupIndex("2E") + Controller_ServiceHandling.GetServiceTestGroupTitle("2E");
            ws.Cells[startRowIndex, TestcaseVariables.ObjectTypeColumnIndex] = TestcaseVariables.ObjectType[1];

            rowIndex++;
        }

        public static void AllowSessionComponent(Worksheet ws, int startRowIndex)
        {
            
        }
        public static void AddressingModeComponent(Worksheet ws, int startRowIndex)
        {

        }
       
        public static void SuppressBitComponent(Worksheet ws, int startRowIndex)
        {

        }
        public static void DIDComponent(Worksheet ws, int startRowIndex)
        {

        }
        public static void ConditionCheckComponent(Worksheet ws, int startRowIndex)
        {

        }
        public static void NRCComponent(Worksheet ws, int startRowIndex)
        {

        }
    }
}

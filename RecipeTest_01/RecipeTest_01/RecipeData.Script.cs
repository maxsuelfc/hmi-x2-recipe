//--------------------------------------------------------------
// Press F1 to get help about using script.
// To access an object that is not located in the current class, start the call with Globals.
// When using events and timers be cautious not to generate memoryleaks,
// please see the help for more information.
//---------------------------------------------------------------

/*
	*******************************************************************
	All examples in this support document are only intended
	to improve understanding of the functionality and 
	handling of the equipment. 
	Beijer Electronics Inc. cannot assume any liability if these
	examples are used in real applications.
	In view of the wide range of applications for this 
	equipment, users must acquire sufficient knowledge 
	themselves in order to ensure that it is correctly used in 
	their specific application. Persons responsible for the 
	application and the equipment must themselves 
	ensure that each application is in compliance with all 
	relevant requirements, standards and legislation in 
	respect to configuration and safety.
	Beijer Electronics Inc. will accept no liability for any 
	damage incurred during the installation or use of this 
	equipment.
	Beijer Electronics Inc. prohibits all modification, changes
	or conversion of the equipment.
	*******************************************************************
*/

namespace Neo.ApplicationFramework.Generated
{
    using System.Windows.Forms;
    using System;
    using System.Drawing;
    using Neo.ApplicationFramework.Tools;
    using Neo.ApplicationFramework.Common.Graphics.Logic;
    using Neo.ApplicationFramework.Controls;
    using Neo.ApplicationFramework.Interfaces;
	//Added by programmer
	using System.Collections.Generic;
	using System.Globalization;
	using System.Threading;
    //
	using System.IO;
	using System.Reflection;
	using System.Data;
    
    public partial class RecipeData
    {	
		// Create table
		DataTable table = new DataTable();
		// Create Columns Header
		string[] StringCol={"ID","X","Y","Z","Torque","Delta T","Driver","Feeder"};
		// Maximum number of rows
		int nLineMax = 20;
		//
		int[,] MatrixVar=new int[20,20];
		//
		// Event screen is opened
		void RecipeData_Opened(System.Object sender, System.EventArgs e)
		{	
			// Mapping tags to var
			mapTagVar();
			// Verifica se há coluna na tabela
			if (table.Columns.Count<=0)
			{
				table.Columns.Add(StringCol[0],typeof(int)); // Add header column 0 
				for(int i=1; i<StringCol.Length; i++)
				{
					table.Columns.Add(StringCol[i],typeof(float));
				}
				DataGrid.DataSource = table;
			}
			UpdateTable();	
		}
		
		void UpdateLine(int LineNumber)// Method to update row
		{
			DataRow Line = table.Rows[LineNumber];
			LineNumber = LineNumber+1;
			switch (LineNumber)
			{ 
				case 1:
					Globals.Tags.ScrewID_01.Value=1;
					Line[StringCol[0]] = Globals.Tags.ScrewID_01.Value;
					Line[StringCol[1]] = Globals.Tags.ScrewPosX_01.Value;
					Line[StringCol[2]] = Globals.Tags.ScrewPosY_01.Value;
					Line[StringCol[3]] = Globals.Tags.ScrewPosZ_01.Value;
					break;
				case 2:
					Globals.Tags.ScrewID_02.Value=2;
					Line[StringCol[0]] = Globals.Tags.ScrewID_02.Value;
					Line[StringCol[1]] = Globals.Tags.ScrewPosX_02.Value;
					Line[StringCol[2]] = Globals.Tags.ScrewPosY_02.Value;
					Line[StringCol[3]] = Globals.Tags.ScrewPosZ_02.Value;
					break;
				case 3:
					Globals.Tags.ScrewID_03.Value=3;
					Line[StringCol[0]] = Globals.Tags.ScrewID_03.Value;
					Line[StringCol[1]] = Globals.Tags.ScrewPosX_04.Value;
					Line[StringCol[2]] = Globals.Tags.ScrewPosY_04.Value;
					Line[StringCol[3]] = Globals.Tags.ScrewPosZ_04.Value;
					break;
				case 4:
					Globals.Tags.ScrewID_04.Value=4;
					Line[StringCol[0]] = Globals.Tags.ScrewID_04.Value;
					Line[StringCol[1]] = Globals.Tags.ScrewPosX_04.Value;
					Line[StringCol[2]] = Globals.Tags.ScrewPosY_04.Value;
					Line[StringCol[3]] = Globals.Tags.ScrewPosZ_04.Value;
					break;
				case 5:
					Globals.Tags.ScrewID_05.Value=5;
					Line[StringCol[0]] = Globals.Tags.ScrewID_05.Value;
					Line[StringCol[1]] = Globals.Tags.ScrewPosX_05.Value;
					Line[StringCol[2]] = Globals.Tags.ScrewPosY_05.Value;
					Line[StringCol[3]] = Globals.Tags.ScrewPosZ_05.Value;
					break;
				default:
					break;
			}
					
		}
		
		void UpdateTable()// Method to update table 
		{
			mapTagVar();
			int[] array=getRow(MatrixVar,0);
			int maxID = findMaxArray(array);
			//
			Globals.Tags.Tag01.Value=maxID; // debug
			Globals.Tags.Tag02.Value=table.Rows.Count; // debug
			//
			table.Rows.Clear();
			AddNewLine(maxID);
			
			for(int i=0 ;i<table.Rows.Count; i++)
			{
				DataRow Line = table.Rows[i];
				for(int j=0 ;j<table.Columns.Count; j++)
				{
					Line[StringCol[j]] = MatrixVar[i,j];
				}
			}
			
		}
		
		void AddNewLine (int nLines) // Method to add Row to table
		{
			if (nLines < nLineMax && table.Rows.Count< nLineMax)
			{
				for (int i=0; i< nLines;i++)
				{
					DataRow Line = table.NewRow();
					table.Rows.Add(Line);
				}
			}
		}
		
		void RemoveLine (int nLines) // Method to add Row to table
		{
			if (nLines > 0 && table.Rows.Count > 0)
			{
				for (int i=0; i<nLines;i++)
				{
					DataRow Line = table.Rows[table.Rows.Count-i-1];
					Line.Delete();
				}
			}
		}
		
		void ComboBox_SelectionChanged(System.Object sender, System.EventArgs e)
		{
		}
		
		void Button4_Click(System.Object sender, System.EventArgs e)
		{
			AddNewLine(1); // Add Row to table
			//UpdateTable();
		}
		
		void Button5_Click(System.Object sender, System.EventArgs e)
		{
			RemoveLine(1);
		}
		
		void Button3_Click(System.Object sender, System.EventArgs e)
		{	
			UpdateTable();		
		}
	
		void Button_Click(System.Object sender, System.EventArgs e)
		{
			if (table.Columns.Count>0)
			{
				UpdateTable();
			}
		}
	
		void AnalogNumeric_ValueChanged(System.Object sender, Core.Api.DataSource.ValueChangedEventArgs e)
		{
			if (table.Columns.Count>0)
			{
				UpdateTable();
			}
		}
		void mapTagVar()
		{
			// Mapping Tags to Var
			// IDrow array
			MatrixVar[0,0] = Globals.Tags.ScrewID_01.Value;
			MatrixVar[1,0] = Globals.Tags.ScrewID_02.Value;
			MatrixVar[2,0] = Globals.Tags.ScrewID_03.Value;
			MatrixVar[3,0] = Globals.Tags.ScrewID_04.Value;
			MatrixVar[4,0] = Globals.Tags.ScrewID_05.Value;
			MatrixVar[5,0] = Globals.Tags.ScrewID_06.Value;
			MatrixVar[6,0] = Globals.Tags.ScrewID_07.Value;
			MatrixVar[7,0] = Globals.Tags.ScrewID_08.Value;
			MatrixVar[8,0] = Globals.Tags.ScrewID_09.Value;
			MatrixVar[9,0] = Globals.Tags.ScrewID_10.Value;
			// Xrow array
			MatrixVar[0,1] = Globals.Tags.ScrewPosX_01.Value;
			MatrixVar[1,1] = Globals.Tags.ScrewPosX_02.Value;
			MatrixVar[2,1] = Globals.Tags.ScrewPosX_03.Value;
			MatrixVar[3,1] = Globals.Tags.ScrewPosX_04.Value;
			MatrixVar[4,1] = Globals.Tags.ScrewPosX_05.Value;
			MatrixVar[5,1] = Globals.Tags.ScrewPosX_06.Value;
			MatrixVar[6,1] = Globals.Tags.ScrewPosX_07.Value;
			MatrixVar[7,1] = Globals.Tags.ScrewPosX_08.Value;
			MatrixVar[8,1] = Globals.Tags.ScrewPosX_09.Value;
			MatrixVar[9,1] = Globals.Tags.ScrewPosX_10.Value;
		}
		void mapVarTag()
		{
			// Mapping Var to Tags
			// IDrow array
			Globals.Tags.ScrewID_01.Value = MatrixVar[0,0];
			Globals.Tags.ScrewID_02.Value = MatrixVar[1,0];
			Globals.Tags.ScrewID_03.Value = MatrixVar[2,0];
			Globals.Tags.ScrewID_04.Value = MatrixVar[3,0];
			Globals.Tags.ScrewID_05.Value = MatrixVar[4,0];
			Globals.Tags.ScrewID_06.Value = MatrixVar[5,0];
			Globals.Tags.ScrewID_07.Value = MatrixVar[6,0];
			Globals.Tags.ScrewID_08.Value = MatrixVar[7,0];
			Globals.Tags.ScrewID_09.Value = MatrixVar[8,0];
			Globals.Tags.ScrewID_10.Value = MatrixVar[9,0];
			// Xrow array
			Globals.Tags.ScrewPosX_01.Value = MatrixVar[0,1];
			Globals.Tags.ScrewPosX_02.Value = MatrixVar[1,1];
			Globals.Tags.ScrewPosX_03.Value = MatrixVar[2,1];
			Globals.Tags.ScrewPosX_04.Value = MatrixVar[3,1];
			Globals.Tags.ScrewPosX_05.Value = MatrixVar[4,1];
			Globals.Tags.ScrewPosX_06.Value = MatrixVar[5,1];
			Globals.Tags.ScrewPosX_07.Value = MatrixVar[6,1];
			Globals.Tags.ScrewPosX_08.Value = MatrixVar[7,1];
			Globals.Tags.ScrewPosX_09.Value = MatrixVar[8,1];
			Globals.Tags.ScrewPosX_10.Value = MatrixVar[9,1];
		}
		
		int findMaxArray(int[] array)
		{
			int max = array[0];
			if (array.Length>1)
			{
				for(int i=1; i<array.Length; i++)
				{
					if(max<array[i])
					{
						max=array[i];
					}
				}
			}
			return max;	
		}
		
		int[] getRow(int[,] matrix, int nCol)
		{
			int[] array=new int[nLineMax];
			for(int i=0; i<array.Length;i++)
			{
				array[i]=matrix[i,nCol];
			}
			return array;
		}
		

	}
}

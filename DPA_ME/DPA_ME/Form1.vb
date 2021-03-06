﻿Imports System.IO 'retrieves the module needed for the stream writer and reader.
Public Class Form1
    Private Const strFileName As String = "File1.txt" 'variable that holds the name of the file we want to use.

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ReadFile() 'Runs the readfile subroutine.
        If ListBox1.Items.Count > 0 Then 'as long as there is a record in the listbox.
            ListBox1.SelectedIndex = 0 'selects the top 
        End If
    End Sub

    Private Sub ReadFile()
        'Open file or create a new one if it does not exist.
        Dim FS As New FileStream(strFileName, FileMode.OpenOrCreate, FileAccess.Read)
        'Associate StreamReader with file
        Dim SR As New StreamReader(FS)
        'Read all lines from file
        Do Until SR.EndOfStream
            'and add to ListBox
            ListBox1.Items.Add(SR.ReadLine)
        Loop
        'Close stream and file
        SR.Close()
        FS.Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        'Check if a valid index
        'This is necessary because being an automatic event procedure
        'it is called whenever the ListBox index changes, and this incudes
        'when a row is deleted, in which case there is temporarily no row
        'selected and the index is set to -1
        If ListBox1.SelectedIndex <> -1 Then
            'Get record from ListBox
            OutputRecord(ListBox1.SelectedItem.ToString)
        End If
    End Sub

    Private Sub OutputRecord(ByVal strRecord As String)
        'Extract fields and output to TextBoxes
        txtStockID.Text = strRecord.Substring(0, intStockIDLen)
        txtDescription.Text = strRecord.Substring(intStockIDLen, intDescriptionLen).TrimEnd
        txtPrice.Text = strRecord.Substring(intStockIDLen + intDescriptionLen, intPriceLen)
        txtQuantityInStock.Text = strRecord.Substring(intStockIDLen + intDescriptionLen + intPriceLen, intQuantityInStockLen)
        txtReorderLevel.Text = strRecord.Substring(intStockIDLen + intDescriptionLen + intPriceLen + intQuantityInStockLen, intReorderLevelLen)
        txtReorderQuantity.Text = strRecord.Substring(intStockIDLen + intDescriptionLen + intPriceLen + intQuantityInStockLen + intReorderLevelLen, intReorderQuantityLen)
        txtDateLastOrder.Text = strRecord.Substring(intStockIDLen + intDescriptionLen + intPriceLen + intQuantityInStockLen + intReorderLevelLen + intReorderQuantityLen, intDateLastOrderLen)
        txtWhetherReceived.Text = strRecord.Substring(intStockIDLen + intDescriptionLen + intPriceLen + intQuantityInStockLen + intReorderLevelLen + intReorderQuantityLen + intDateLastOrderLen)
    End Sub

    'Get fields from TextBoxes and format into record
    Private Function InputRecord() As String
        'Format string fields to specified length with spaces on right
        'and numerical fields (or ID) to specified length with zeros on left:
        Dim strStockID As String = txtStockID.Text.PadLeft(intStockIDLen, ChrW(48))
        Dim strDescription As String = txtDescription.Text.PadRight(intDescriptionLen, ChrW(32))
        Dim strPrice As String = txtPrice.Text.PadLeft(intPriceLen, ChrW(48))
        Dim strQuantityInStock As String = txtQuantityInStock.Text.PadLeft(intQuantityInStockLen, ChrW(48))
        Dim strReorderLevel As String = txtReorderLevel.Text.PadLeft(intReorderLevelLen, ChrW(48))
        Dim strReorderQuantity As String = txtReorderQuantity.Text.PadLeft(intReorderQuantityLen, ChrW(48))
        Dim strDateLastOrder As String = txtDateLastOrder.Text.PadRight(intDateLastOrderLen, ChrW(32))
        Dim strWhetherReceived As String = txtWhetherReceived.Text.PadRight(intWhetherReceivedLen, ChrW(32))
        'Concatenate fields and return record
        Return strStockID & strDescription & strPrice & strQuantityInStock & strReorderLevel & strReorderQuantity & strDateLastOrder & strWhetherReceived
    End Function

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        'Append new record to end of ListBox
        ListBox1.Items.Add(InputRecord)
        'Select the record just appended
        ListBox1.SelectedIndex = ListBox1.Items.Count - 1
    End Sub

    Private Sub btnAmend_Click(sender As System.Object, e As System.EventArgs) Handles btnAmend.Click
        'Replace record in ListBox at selected position
        ListBox1.Items(ListBox1.SelectedIndex) = InputRecord()
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        'Memorize number of records
        Dim intNumRecs As Integer = ListBox1.Items.Count
        'If there are any records
        If intNumRecs > 0 Then
            'Memorize which record is currently selected
            Dim intSelRec As Integer = ListBox1.SelectedIndex
            'Remove currently selected record
            'This module does not have a separate RemoveRec procedure
            ListBox1.Items.RemoveAt(intSelRec)
            'decrement the number of records
            intNumRecs -= 1
            'If it was the last one (so there are none left)
            If intNumRecs = 0 Then
                'remove display
                ClearBoxes()
            Else
                'if it was the record on the end
                If intSelRec = intNumRecs Then
                    'move selection row up
                    intSelRec -= 1
                End If
                'Update selection
                ListBox1.SelectedIndex = intSelRec
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        'Open disk file stream for writing
        Dim SW As New StreamWriter(strFileName)
        'For all the lines in the ListBox
        For Each Item In ListBox1.Items
            'Write to the file replacing previous contents
            SW.WriteLine(Item)
        Next
        'Close stream
        SW.Close()
    End Sub

    'Remove all displayed fields
    Private Sub ClearBoxes()
        txtStockID.Clear()
        txtDescription.Clear()
        txtPrice.Clear()
        txtQuantityInStock.Clear()
        txtReorderLevel.Clear()
        txtReorderQuantity.Clear()
        txtDateLastOrder.Clear()
        txtWhetherReceived.Clear()
    End Sub

    Private Sub btnReport_Click(sender As System.Object, e As System.EventArgs) Handles btnReport.Click
        'Variables for separate fields
        Dim strStockID As String
        Dim strDescription As String
        Dim strPrice As String
        Dim strQuantityInStock As String
        Dim strReorderLevel As String
        Dim strReorderQuantity As String
        Dim strDateLastOrder As String
        Dim strWhetherReceived As String

        'Line to write to file
        Dim strLine As String = ""
        'Stock value variables
        Dim sngTotalHeld As Single = 0
        Dim sngTotalOnOrder As Single = 0

        'Open disk file stream for writing
        Dim SW As New StreamWriter("StockReport.txt")

        'For all the lines in the ListBox
        For Each Item In ListBox1.Items
            'Get separate fields from record
            strStockID = Item.Substring(0, intStockIDLen)
            strDescription = Item.Substring(intStockIDLen, intDescriptionLen)
            strPrice = Item.Substring(intStockIDLen + intDescriptionLen, intPriceLen)
            strQuantityInStock = Item.Substring(intStockIDLen + intDescriptionLen + intPriceLen, intQuantityInStockLen)
            strReorderLevel = Item.Substring(intStockIDLen + intDescriptionLen + intPriceLen + intQuantityInStockLen, intReorderLevelLen)
            strReorderQuantity = Item.Substring(intStockIDLen + intDescriptionLen + intPriceLen + intQuantityInStockLen + intReorderLevelLen, intReorderQuantityLen)
            strDateLastOrder = Item.Substring(intStockIDLen + intDescriptionLen + intPriceLen + intQuantityInStockLen + intReorderLevelLen + intReorderQuantityLen, intDateLastOrderLen)
            strWhetherReceived = Item.Substring(intStockIDLen + intDescriptionLen + intPriceLen + intQuantityInStockLen + intReorderLevelLen + intReorderQuantityLen + intDateLastOrderLen)

            'Update total value of stock held
            sngTotalHeld += CSng(strPrice) * CSng(strQuantityInStock)

            'If stock level too low
            If CInt(strQuantityInStock) <= CInt(strReorderLevel) Then
                'Build output line
                strLine = strStockID & " " & strDescription
                If strWhetherReceived = "True" Then
                    strLine &= " Not ordered yet"

                Else
                    strLine &= " Order for " & strReorderQuantity & " sent " & DateDiff(DateInterval.Day, CDate(strDateLastOrder), Today).ToString & " days ago"
                    'Update total of value on order

                    sngTotalOnOrder += CSng(strPrice) * CInt(strReorderQuantity)

                End If
                'Add new Item line to file
                SW.WriteLine(strLine)
            End If
        Next
        'Add summary information
        SW.WriteLine("Total value of stock held: £" & sngTotalHeld.ToString)
        SW.WriteLine("Total value of stock on order: £" & sngTotalOnOrder.ToString)
        'Close stream
        SW.Close()
      
        'Open text file in Notepad
        System.Diagnostics.Process.Start("StockReport.txt")
    End Sub
End Class

﻿'=========================================================================='
'                                                                          '
'                    (C) Copyright 2018 Devil7 Softwares.                  '
'                                                                          '
' Licensed under the Apache License, Version 2.0 (the "License");          '
' you may not use this file except in compliance with the License.         '
' You may obtain a copy of the License at                                  '
'                                                                          '
'                http://www.apache.org/licenses/LICENSE-2.0                '
'                                                                          '
' Unless required by applicable law or agreed to in writing, software      '
' distributed under the License is distributed on an "AS IS" BASIS,        '
' WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. '
' See the License for the specific language governing permissions and      '
' limitations under the License.                                           '
'                                                                          '
' Contributors :                                                           '
'     Dineshkumar T                                                        '
'=========================================================================='

Imports System.Text.RegularExpressions

Public Class GSTINValidator

#Region "Variables/Constants"
    Private Const GSTIN_REGEX As String = "[0-9]{2}[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9A-Za-z]{1}[Z]{1}[0-9a-zA-Z]{1}"
    Private Const CHECKSUM_CHARS As String = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"
#End Region

#Region "Subs/Functions"
    ''' <summary>
    ''' Method to check if a GSTIN Is valid. Checks the GSTIN format And the check digit Is valid for the passed input GSTIN
    ''' </summary>
    ''' <param name="GSTIN">GSTIN to Validate</param>
    Public Shared Function IsValid(ByVal GSTIN As String, Optional ByRef ErrorStr As String = Nothing) As Boolean
        Try
            Validate(GSTIN)
            Return True
        Catch ex As Exception
            If ErrorStr IsNot Nothing Then
                ErrorStr = ex.Message
            End If
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Method to check if a GSTIN Is valid. Throws if GSTIN is not valid with error in message.
    ''' </summary>
    ''' <param name="GSTIN">GSTIN to Validate</param>
    Public Shared Sub Validate(ByVal GSTIN As String)
        GSTIN = GSTIN.Trim
        If String.IsNullOrEmpty(GSTIN) Then
            Throw New Exception("GSTIN is empty")
        Else
            If Regex.IsMatch(GSTIN, GSTIN_REGEX) Then
                If Not GSTIN(GSTIN.Length - 1).Equals(GenerateCheckSum(GSTIN.Substring(0, GSTIN.Length() - 1))) Then
                    Throw New Exception("GSTIN is invalid")
                End If
            Else
                Throw New Exception("GSTIN doesn't match the pattern")
            End If
        End If
    End Sub

    ''' <summary>Generates and returns checksum digit for given GSTIN (without checksum digit)</summary>
    ''' <param name="GSTIN">GSTIN without checksum digit to generate checksum digit</param>
    Private Shared Function GenerateCheckSum(ByVal GSTIN As String) As Char
        Dim factor As Integer = 2
        Dim sum As Integer = 0
        Dim checkCodePoint As Integer = 0
        Dim cpChars As Char()
        Dim inputChars As Char()

        If String.IsNullOrEmpty(GSTIN) Then
            Throw New Exception("GSTIN supplied for checkdigit calculation is null")
        End If
        cpChars = CHECKSUM_CHARS.ToCharArray()
        inputChars = GSTIN.ToUpper.ToCharArray()

        Dim Mod_ As Integer = cpChars.Length
        For i As Integer = inputChars.Length - 1 To 0 Step -1
            Dim codePoint As Integer = -1
            For j As Integer = 0 To cpChars.Length - 1
                If cpChars(j) = inputChars(i) Then
                    codePoint = j
                    Exit For
                End If
            Next
            Dim digit As Integer = factor * codePoint
            factor = If(factor = 2, 1, 2)
            digit = (digit \ Mod_) + (digit Mod Mod_)
            sum += digit
        Next
        checkCodePoint = (Mod_ - (sum Mod Mod_)) Mod Mod_
        Return cpChars(checkCodePoint)
    End Function
#End Region

End Class

   M S B A M L   `   `   `  ����H  DBlueberry.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Blueberry.WPF.Pages.EmployeePages!Blueberry.WPF.Pages.EmployeePages  5      E'clr-namespace:Blueberry.WPF.DialogBoxesBlueberry.WPF.DialogBoxes  5      7    1Blueberry.WPF.Pages.EmployeePages.NewEmployeePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:Blueberry.WPF.Pages.EmployeePages     5      ;dialogs'clr-namespace:Blueberry.WPF.DialogBoxes     5        N� Title$  NewEmployeePage��5	       N� 
Background
 ����� � 	Resources 5      5   /Blueberry.WPF.Pages.EmployeePages.NewEmployeeVM 	  Model��%   &	          5   
   6   5      .��5      ��  � DataContext# [  6    5   
    �� 
TargetType  TextBlockStyle �� Property �� Value  ButtonStyle  OuterBorderStyle �� Triggers P� Property	 P� Value  TextBoxStyle��%�  &	       &	 �     &	 +    &	 �    �� 5      " ��6   .�5      ��  � ��$ 25(�6-   �� 5       � ��$ Center=�66   �� 5       � ��$
 20,5q�6+   5      �� 5      " ��6   .�5      ��  � ��$ 25(�6-   �� 5       � �� �#7f90b06/   �� 5       � ��$ 0q�64   5      �� 5      " ��6   .�5      ��  �@��Padding$ 5q�6,   �� 5       � ��$	 150��6*   �� 5       � ��$ 20q�6+   �� 5        �@��CornerRadius$ 5��61   �� 5!       � �� �#7f90b06/   �� 5"       � ��$ 0,0,1,1q�64   �� 5#       � ��
 �����60    5$      P� 5%       �@J�IsMouseOver	 . . �5&      ��  �@�Cursor$
 Hand��63   5'      5)      �� 5+      " ��6   .�5,      ��  � ��$ 25(�6-   �� 5-       � ��$ 5q�6,   �� 5.       � ��$
 20,5q�6+   �� 5/       � ��$ Center=�66   �� 50       � ��$	 200��6*   51      52      .+�54   
   5   /Blueberry.WPF.DialogBoxes.NotificationDialogBox  -   5        
  Name$
 AddDialogBox��55      )   #Blueberry.WPF.DialogBoxes.DialogBox   Caption$ Pracownik został dodany��56      0   *Blueberry.WPF.DialogBoxes.CommandDialogBox   CommandBefore 57      ��  �� Path$ 
AddCommand�   CommandAfter 58      �� $ ChangeContentCommand�  59   
   -   5        $
 DiscardDialogBox��5:      $ Zmiany zostaną wycofane��5;       5<      �� $ DiscardCommand� 5=      �� $ ChangeContentCommand��� 5?   
   $ ��Wprowadź dane Pracownika:��6   $��Center=�5@      $��30(�5A      $��10q�6"   � 5C   
   $��Center=�6    � ColumnDefinitions 5D      �� 5E      $
��Auto �6#   �� 5F      $
��Auto �6#   �� 5G      $��* �6#    � RowDefinitions 5I      �� 5J      �� 5K      �� 5L      �� 5M      �� 5N      �� 5O      .+�5R      �� $��0��6   $��0��6(   $��Imię: ��5S      #��[ 5T      �� 5U      $��1��6   $��0��6&   #��[ 5W      ��5V      �� *	FirstName+5W      �� 5Y      $��0��6   $��1��6(   $��
Nazwisko: ��5Z      #��[ 5[      �� 5\      $��1��6   $��1��6&   #��[ 5^      ��5]      �� *
LastName+5^      �� 5`      $��0��6   $��2��6(   $��Numer telefonu: ��5a      #��[ 5b      �� 5c      $��1��6   $��2��6&   #��[ 5e      ��5d      �� $ PhoneNumber�5e      �� 5g      $��0��6   $��3��6(   $��Stawka: ��5h      #��[ 5i      �� 5j      $��1��6   $��3��6&   #��[ 5l      ��5k      �� $
 Rate�5l      �� 5n      $��5��6   $��0��6"   #��[ 62   ._�5o      �� $��Dodaj��6   #��[ 5p      ��5o   )   ��  �� ElementName$ AddDialogBox��$
 Show�5p      5q      �� 5r      $��5��6   $��1��6"   #��[ 62   ._�5s      �� $��Anuluj��6   #��[ 5t      ��5s   *   �� $ DiscardDialogBox��$
 Show�5t      5u      5v      � 5x   
    5y      �� 5z      $
��Auto �6#   �� 5{      $
��Auto �6#   �� 5|      $��* �6#   5      5�      5�      
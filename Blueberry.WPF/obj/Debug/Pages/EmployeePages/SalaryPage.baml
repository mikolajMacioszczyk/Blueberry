   M S B A M L   `   `   `  ����H  DBlueberry.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Blueberry.WPF.Pages.EmployeePages!Blueberry.WPF.Pages.EmployeePages  5      G(clr-namespace:Blueberry.WPF.UserControlsBlueberry.WPF.UserControls  5      i9clr-namespace:Blueberry.WPF.UserControls.EmployeeControls+Blueberry.WPF.UserControls.EmployeeControls  5      2    ,Blueberry.WPF.Pages.EmployeePages.SalaryPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:Blueberry.WPF.Pages.EmployeePages     5      AuserControls(clr-namespace:Blueberry.WPF.UserControls     5      VemployeeControls9clr-namespace:Blueberry.WPF.UserControls.EmployeeControls     5        N� Title$  
SalaryPage��5
       � 	Resources 5      4   .Blueberry.WPF.Pages.EmployeePages.SalaryPageVM 	  Model��%   &	          5   
   6   5      .��5      ]�  � DataContext# [  6   $��10q�65   .+�5   
   �� $	��Top=�6    �� Orientation$ 
Horizontal=�6*   $��Center=�6C   $��0,0,0,10q�6`   .+�5      �� $��../Images/coin.png��6   $��70��60   $
��10,0q�6;   �� 5      $	��Top=�6   $��Wypłaty��6-    �� TextAlignment$ Center=�6<   $��40(�6S   5      � 5   
    5       �� 
TargetType  GroupTextBlockStyle �� Property �� Value��%x   &	       �� 5      " ��6   .�5      ��  � ��$ 20(�61   �� 5       � ��$
 0, 5q�6/   5      5       � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5"      � $��0��6   	 � RowDefinitions	 5#      �� 5$      $
��Auto �6$   �� 5%      $��* �6$   .+�5(      �� ��5)      �� 5*      $��Sortuj pracowników po:��6$   #��[ 6B   .��5-      �� $ Vertical=�6!   .+�5.      	� $��ByName��6E   ��6&   �� *
ChangeSort+.��5/      �� $��Nazwisku��6(   #��[ 68   50      	� 51      $��ByRate��6E   ��6&   �� *
ChangeSort+.��52      �� $��Stawce��6(   #��[ 66   53      	� 54      $��ByCollected��6E   ��6&   �� *
ChangeSort+.��55      �� $��	Zebranych��6(   #��[ 69   56      	� 57      $��
ByUnpaided��6E   ��6&   �� *
ChangeSort+.��58      �� $��Nieopłaconych��6(   #��[ 6=   59      5:      5;      5<      �� 5?      $��1��6   .+�5A      �� 
 �� Padding$
 5q�5B       �� CornerRadius$ 3��6%   $��0,0,0,3q�5C      ���#7f90b0��5A      ��  �� ElementName$ SalaryItemsControl��._�5D      H   BBlueberry.WPF.UserControls.EmployeeControls.EmployeeTemplateHeader  5E      �� 5G      .��5H      �� $
��20,0q�5I   #   ��5H   #   ��  �� Path$ SalaryModels���5J      �� 5K      .R�5L   "   �� 5M      ��5O      �� 5P      .R�5Q   "   �� $
 5q�5R   )   $ 3��65   $��0,0,0,3q�5S   )   
���������5Q   )   �� $ SalaryItemsControl��._�5T   &   @   :Blueberry.WPF.UserControls.EmployeeControls.SalaryTemplate   6F   �� 5U   #   5V      5X      5Y      5Z      5[      5\      5]      
   M S B A M L   `   `   `  ����H  DBlueberry.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Xclr-namespace:Blueberry.WPF.UserControls.EmployeeControls.EmployeeTemplateImplementationJBlueberry.WPF.UserControls.EmployeeControls.EmployeeTemplateImplementation  5      ]    WBlueberry.WPF.UserControls.EmployeeControls.EmployeeTemplateImplementation.ShowEmployee   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      jlocalXclr-namespace:Blueberry.WPF.UserControls.EmployeeControls.EmployeeTemplateImplementation     5      .��5	      �   � 	Resources  5
   
    �� 
TargetType   ButtonStyle �� Property �� Value  BorderStyle �� Triggers P� Property P� Value  TextBlockStyle��%�  &	        &	 �     &	     �� 5      " ��6   .�5      ��  � �� �#7f90b06/   �� 5       � ��$ 0q�64   �� 5       � ��$ 25(�6-   5      �� 5      " ��6   .�5      ��  � �� �#7f90b06/   �� 5       � ��$ 0,0,1,1q�64   �� 5       �@��Padding$ 5q�6,   �� 5       �@��CornerRadius$ 5��61   �� 5       � ��$	 150��6*   �� 5       � ��$ 10q�6+    5      P� 5       �@J�IsMouseOver . . �5      ��  �@�Cursor$
 Hand��63   5      5      �� 5      " ��6   .�5      ��  � ��$ 25(�6-   �� 5       � ��$ 5q�6+   5       5!       � RowDefinitions 5#   
   �� 5$      $��* �6   �� 5%      $��* �6   �� 5&      $��* �6   �� 5'      $��* �6   �� 5(      $��* �6   �� 5)      $��* �6   �� 5*      $
��0.5* �6   �� 5+      $��* �6   .+�5.   
   �� $��0��6   #��[ 50      ��5/      ��  �� Path$ Employee.FirstName�	 �� StringFormat$	 	Imie: {0}��50      �� 52   
   $��1��6   #��[ 54      ��53      �� $ Employee.LastName�$	 Nazwisko: {0}��54      �� 56   
   $��2��6   #��[ 58      ��57      �� $ Employee.PhoneNumber�$	 
Numer: {0}��58      �� 5:   
   $��3��6   #��[ 5<      ��5;      �� $ Employee.Rate�$	 Stawka: {0}��5<      �� 5>   
   $��4��6   #��[ 5@      ��5?      �� $ Employee.TotalCollected�$	 Zebrane razem: {0}��5@      �� 5B   
   $��5��6   #��[ 5D      ��5C      �� $ Employee.UnPaided�$	 Nieopłacone: {0}��5D      �� 5F   
   $��7��6   
 �� Orientation$
 
Horizontal=�6"   .+�5G      �� #��[ 6   ._�5H      �� $��Zapłać��6   #��[  6*   ��5I      �� *
PayCommand+5J      �� 5K      #��[ 6   ._�5L      �� $��Edytuj��6   #��[  6*   ��5M      �� *EditCommand+5N      5O      5P      5Q      
   M S B A M L   `   `   `  ����H  DBlueberry.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Xclr-namespace:Blueberry.WPF.UserControls.EmployeeControls.EmployeeTemplateImplementationJBlueberry.WPF.UserControls.EmployeeControls.EmployeeTemplateImplementation  5      ]    WBlueberry.WPF.UserControls.EmployeeControls.EmployeeTemplateImplementation.EditEmployee   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      jlocalXclr-namespace:Blueberry.WPF.UserControls.EmployeeControls.EmployeeTemplateImplementation     5      .��5	      �   � 	Resources  5
   
    �� 
TargetType   ButtonStyle �� Property �� Value  BorderStyle �� Triggers P� Property P� Value  TextBlockStyle  TextBoxStyle��%g  &	        &	 �     &	     &	 �    �� 5      " ��6   .�5      ��  � �� �#7f90b06/   �� 5       � ��$ 0q�64   �� 5       � ��$ 25(�6-   5      �� 5      " ��6   .�5      ��  � �� �#7f90b06/   �� 5       � ��$ 0,0,1,1q�64   �� 5       �@��Padding$ 5q�6,   �� 5       �@��CornerRadius$ 5��61   �� 5       � ��$	 150��6*   �� 5       � ��$ 10q�6+    5      P� 5       �@J�IsMouseOver . . �5      ��  �@�Cursor$
 Hand��63   5      5      �� 5      " ��6   .�5      ��  � ��$ 25(�6-   �� 5       � ��$ 5q�6+   5       �� 5!      " ��6   .�5"      ��  � ��$ 25(�6-   �� 5#       � ��$ 5q�6+   �� 5$       � ��$	 5,0q�6,   �� 5%       � ��$	 180��6*   5&      5'       � RowDefinitions 5)   
   �� 5*      $��* �6   �� 5+      $��* �6   �� 5,      $��* �6   �� 5-      $��* �6   �� 5.      $��* �6   �� 5/      $��* �6   �� 50      $��* �6   �� 51      $
��0.5* �6   �� 52      $��* �6   .+�55   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�56      �� $��Imię: ��6   #��[ 57      �� 58      #��[ 59      ��58      �� *Copy.FirstName+59      5:      �� 5<   
   $��1��6   $ 
Horizontal=�6"   .+�5=      �� $��	Nazwisko:��6   #��[ 5>      �� 5?      #��[ 5@      ��5?      �� *Copy.LastName+5@      5A      �� 5C   
   $��2��6   $ 
Horizontal=�6"   .+�5D      �� $��Numer:��6   #��[ 5E      �� 5F      #��[ 5G      ��5F      �� *Copy.PhoneNumber+5G      5H      �� 5J   
   $��3��6   $ 
Horizontal=�6"   .+�5K      �� $��Stawka:��6   #��[ 5L      �� 5M      #��[ 5N      ��5M      �� *	Copy.Rate+5N      5O      �� 5Q   
   $��4��6   #��[ 5S      ��5R      �� 	 �� Path$	 Employee.TotalCollected�
 �� StringFormat$
 Zebrane razem: {0}��5S      �� 5U   
   $��5��6   #��[ 5W      ��5V      �� $	 Employee.UnPaided�$
 Nieopłacone: {0}��5W      �� 5Y   
   $��6��6   
���  ��#��[ 5\      ��5Z      �� $
	 Info�5\      �� 5^   
   $��8��6   $ 
Horizontal=�6"   .+�5_      �� #��[ 6   ._�5`      �� $��Zapisz��6   #��[  6*   ��5a      �� *SaveCommand+5b      �� 5c      #��[ 6   ._�5d      �� $��Wycofaj��6   #��[  6+   ��5e      �� *DiscardCommand+5f      5g      5h      5i      
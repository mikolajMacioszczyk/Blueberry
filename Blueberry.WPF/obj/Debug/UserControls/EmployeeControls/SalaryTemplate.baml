   M S B A M L   `   `   `  ����H  DBlueberry.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulli9clr-namespace:Blueberry.WPF.UserControls.EmployeeControls+Blueberry.WPF.UserControls.EmployeeControls  5      C&clr-namespace:Blueberry.WPF.ConvertersBlueberry.WPF.Converters  5      @    :Blueberry.WPF.UserControls.EmployeeControls.SalaryTemplate   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Klocal9clr-namespace:Blueberry.WPF.UserControls.EmployeeControls     5      =
converters&clr-namespace:Blueberry.WPF.Converters     5        � 	Resources  5
      8   2Blueberry.WPF.Converters.BoolToVisibilityConverter   VisibilityConverter��%   &	          5   
   6/   5      .��5      ��  �� Orientation$ Vertical=�6   .+�5   
   �   5   
    �� 
TargetType  TextBlockStyle �� Property �� Value  BorderStyle �� Triggers P� Property P� Value  ButtonStyle �� RelativeSource	 �� AncestorType
 �� Path��%`  &	       &	 �     &	 �    �� 5      " ��6   .�5      ��  � ��$ 20(�6-   �� 5       � ��$ Center=�68   �� 5       � ��$	 0,2q�6+   5      �� 5      " ��6   .�5      ��  �@��Padding$ 5q�6,   �� 5       �@��CornerRadius$ 5��61    5      P� 5       �@J�IsMouseOver . . �5      ��  �@�Cursor$
 Hand��63   5      5      �� 5      " ��6   .�5      ��  � ��$ 20(�6-   �� 5        � ��$ 0q�64   �� 5!       � �� 6/   ��  �� *FindAncestor+"	 ��$
 
Background�5"      5#       � ColumnDefinitions 5%   
   �� 5&      $��2* �6   �� 5'      $��* �6   �� 5(      $��* �6   �� 5)      $��* �6   �� 5*      $
��0.7* �6   �� 5+      $
��0.7* �6   .+�5.   
   �� $��0��6   $��0��6%   $ 
Horizontal=�62   $��Center=�6K   .+�5/      �� #��[ 6A   ��6   �� $
 Employee.FirstName�6A   �� 50      $�� ��6   �� 51      #��[ 6@   ��6   �� $
 Employee.LastName�6@   52      �� 55   
   $��1��6   $��0��6%   #��[ 57      ��56      �� $
 Employee.Rate�57      �� 59   
   $��2��6   $��0��6$   ���#7f90b0#��[ 5<      ��5;      �� $
 Employee.TotalCollected�5<      �� 5>   
   $��3��6   $��0��6$   ���#d9455f#��[ 5A      ��5@      �� $
 Employee.UnPaided�5A      �� 5C   
   $��4��6   $��0��6!   #��[ 5D      ._�5E      �� $��	Całość��6   #��[ 6&   ���#a8df65��5G      �� $
 PayAllCommand�5H      �� 5J   
   $��5��6   $��0��6!   #��[ 5K      ._�5L      �� $��Część��6   #��[ 6%   ���#7f90b0��5N      �� *PayPartCommand+5O      5Q      � 5S   
   $��5q�6m   y�6   �� *IsBottomContentVisible+ �� 	Converter# [    5T      ��%�  &	       &	 �     �� 5U      " ��6   .�5V      ��  �@��CornerRadius$ 5��65   �� 5W       � ��$
 10,0q�6/    5X      P� 5Y       �@J�IsMouseOver . . �5Z      ��  �@�Cursor$
 Hand��67   5[      5]      �� 5^      " ��6   .�5_      ��  � ��$ 18(�61   �� 5`       � ��$ 0q�68   �� 5a       � �� 63   ��  �� *FindAncestor+"	 ��$
 
Background�5b      5c       5e      �� 5f      �� 5g      $��3* �6#   �� 5h      �� 5i      .+�5l      �� $��0��6   ��5m      ��  �� ElementName$ 	PaySlider��$
 Value� �� UpdateSourceTrigger$ PropertyChanged=��� 5o      -   5         ��Name$ 	PaySlider��5p      $��1��5o       �� Orientation$ 
Horizontal=�6%    �� TickFrequency$	 0.5Q�6>    �� IsSnapToTickEnabled .  � Value 5p   +   �� *ToPay+ � Maximum 6C   �� $
 Employee.UnPaided��� 5s      $��2��6   #��[ 6%   ._�5t      �� #��[ 6   $��Zapłać��5u      ���#a8df65��5w      �� *AcceptCommand+5x      �� 5z      $��3��6   #��[ 6%   ._�5{      �� #��[ 6   ���#d9455f$��Anuluj��5}      ��5~      �� *DiscardCommand+5      5�      5�      5�      
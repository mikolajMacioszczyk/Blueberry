   M S B A M L   `   `   `  ����H  DBlueberry.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Blueberry.WPF.Pages.CustomersBlueberry.WPF.Pages.Customers  5      1    +Blueberry.WPF.Pages.Customers.CustomersPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Blueberry.WPF.Pages.Customers     5        N� FontSize$  27(�5       N� Title$ CustomersPage��5	       N� 
Background
 ����� � 	Resources 5      3   -Blueberry.WPF.Pages.Customers.CustomersPageVM 	  Model �� 
TargetType  AddButtonStyle �� Property �� Value  OuterBorderStyle �� Triggers P� Property	 P� Value��%�  &	        &	      &	 �       5   
   6    �� 5   
   " ��6   .�5      ��  � ��$	 Top=�62   �� 5       � ��
 �����6+   �� 5       � ��$ 0q�60   5      �� 5   
   " ��6   .�5      ��  �@��Padding$ 5q�6(   �� 5       � ��$ 3q�60   �� 5       � �� �#0042256,   �� 5       �@��CornerRadius$ 10��6-    5      P� 5       �@J�IsMouseOver	 . . �5      ��  �@�Cursor$
 Hand��6/   5      5      5      .��5       ]� 
 � DataContext#
 [  6   $��20q�65   .+�5!   
   �� $
��Left=�6   $��	0,20,15,0q�6+   .+�5"      �� #��[ 6   ._�5#      �� #��[ 6   ��5$      ��  �� Path$ 
AddCommand�.��5%      �� .+�5&      �� $��../Images/add_icone.png��6    $��50��6A   �� 5'      $��Dodaj��6    5(      5)      5*      5+      >� 5.   
   ��6   �� $ 	RightSide�50      51      
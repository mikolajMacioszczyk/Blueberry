   M S B A M L   `   `   `  ����H  DBlueberry.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Blueberry.WPF.PagesBlueberry.WPF.Pages  5      C&clr-namespace:Blueberry.WPF.ViewModelsBlueberry.WPF.ViewModels  5      "    Blueberry.WPF.Pages.HomePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Blueberry.WPF.Pages     5      9models&clr-namespace:Blueberry.WPF.ViewModels     5        N� Title$  HomePage��5
       N� 
Background 5      �� 5   
    �� ImageSource$, &../../Images/BlueberriesBackground.jpg��6    j� Stretch$ UniformToFill=�6J    � 	Resources 5      )   #Blueberry.WPF.ViewModels.HomePageVM 	  Model��%   &	          5   
   6   5      .��5      �  � DataContext# [  6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      .+�5   
   �� $��40q�6    5       �� 
TargetType  DescriptionStyle �� Property	 �� Value  OrdersStyle��%   &	       &	 s     �� 5      " ��6   .�5      ��  � ��$	 30(�61   �� 5       �@��Padding$	 7q�60   5      �� 5      " ��6   .�5      ��  � ��$	 20(�61   �� 5       �@��Padding$	 7q�60   �� 5        � ��$
	 Wrap=�65   5!      5"      .+�5#      �� 
 �� CornerRadius$
 7��6   $��
20,0,20,10q�6&    �� Padding$ 10q�6:   ��5$      �� 5%       �� Color$ #d3dfed��6&    �� Opacity$
 0.85Q�66   ._�5'      �� .+�5(      �� #��[ 6A   ��6    ��  �� Path$ 
DropedInfo�6A   �� 5)      #��[ 6A   ��6    �� $ 
SoldedInfo�6A   �� 5*      #��[ 6F   ��6    �� $ PricePerKgInfo�6F   �� 5+      #��[ 6B   ��6    �� $ 
IncomeInfo�6B   5,      5-      �� 5/      $
 7��6   $��
20,10,20,0q�6&   $ 10q�6:   ��50      �� 51      $ #d3dfed��6&   $
 0.85Q�66   ._�53      �� .+�54      �� $��Oczekujące zamówienia:��6    #��[ 6>   �� 55      #��[ 6C   ��6    �� $ WaitingRoom1�6C   �� 56      #��[ 6C   ��6    �� $ WaitingRoom2�6C   �� 57      #��[ 6C   ��6    �� $ WaitingRoom3�6C   58      59      5:      �� 5<   
   $��1��6   .+�5=      �� $��35(�62   $��Center=�6@   $��Center=�6]   $��0q�6x   ��6   �� $
 Date�6x   �� 5>      $��48(�63   $��Center=�6A   $��Center=�6^   $��0q�6y   ��6   �� $ Timer�6y   5?      5@      5A      
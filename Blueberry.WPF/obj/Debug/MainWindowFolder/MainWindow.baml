   M S B A M L   `   `   `  ����H  DBlueberry.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Blueberry.WPF.MainWindowFolderBlueberry.WPF.MainWindowFolder  5   	   /    )Blueberry.WPF.MainWindowFolder.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:Blueberry.WPF.MainWindowFolder     5   	     � Title$  	Blueberry��5   	   $	��700��6   $
��1400��6(    � WindowStartupLocation$ CenterScreen=�5	   	    � Icon$ ../Images/berry.png��5
   	    � 	Resources 5      .   (Blueberry.WPF.MainWindowFolder.ViewModel 	  Model��%   &	          5   
   6   5      .��5      ]�  � DataContext# [  6   .+�5   
   o� $	��Top=�6   $��30(�6$   .@�5      m� $��Start��6   $
��20,0q�6&    m� CommandParameter$ HomePage��6R    m� Command 65   �� *
GoToPage+6R   m� 5      $��Zamówienia��6   $
��20,0q�6+   $ 	OrderPage��6W    6:   �� *
GoToPage+6W   m� 5      $��	Kalendarz��6   $
��20,0q�6*   $ CalendarPage��6V    69   �� *
GoToPage+6V   m� 5      $��Klienci��6   $
��20,0q�6(   $ CustomersPage��6T    67   �� *
GoToPage+6T   m� 5      $��Zbiory��6   $
��20,0q�6'   .@�5      m� $��Dodaj��6   $ NewHarvestPage��6G    6*   �� *
GoToPage+6G   m� 5      $��Historia��6   $ HarvestHistoryPage��6J    6-   �� *
GoToPage+6J   5      m� 5      $��
Pracownicy��6   $
��20,0q�6+   .@�5      m� $��Wszyscy��6   $ EmployerPage��6I    6,   �� *
GoToPage+6I   m� 5      $��Wypłaty��6   $ 
SalaryPage��6I    6,   �� *
GoToPage+6I   m� 5      $
��Nowy��6   $ NewEmployeePage��6F    6)   �� *
GoToPage+6F   5      m� 5      $��	Statystki��6   $ StatisticsPage��6G    6*   �� *
GoToPage+6G   5       � 5   
     � NavigationUIVisibility$ Hidden=�64   ��6   ��  �� Path$ 
ActualPage�64   5       5!      
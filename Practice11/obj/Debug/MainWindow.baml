   M S B A M L   `   `   `  ????E  APractice11, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Practice11
Practice11  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 5   	       Practice11.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Practice11     5   	   Bcol2clr-namespace:System.Collections;assembly=mscorlib     5   	     ? Title$  
MainWindow??5	   	   $	??450??5
      $	??800??5      .??5      ? -   5         ?Name$ Bank_Account??5       ? ColumnDefinitions 5   
   ?? 5      $
??457* ?6   ?? 5      $
??343* ?6   .+?5   
   ?? -   5         ??Name$ 
ClientList??5      $??
10,10,1,10q?5       ?? View 5      ?? 5      .P?5      ??  ?? Width$	 150??5       ?? DisplayMemberBinding 5      ??  ?? Path$ 	FirstName?.??5   %   
First Name5      ?? 5      $	 150??5        5      ?? $ LastName?.??5    %   	Last Name5"      ?? 5#      $	 150??5&       5$      ?? $ FathersName?.??5&   %   Fathers Name5(      5)      5+      ?? 5-   
   $??21,10,0,321q?6   $??2??6*   .+?5.      ?? -   5         ??Name$ Accounts??5.      $??21(?5/      $
??Bold"?50      $??66??51      $	??279??52      	 ?? Text$	 Choose Account??53      $??Center=?54      $??Center=?55      $??Center=?56      $??Center=?57      $??2,2,2,2q?58      
 ?? 
IsEditable
 . .@?5;      ?? -   5         ??Name$ Account1??5;      
Consultant6:   ?? 5<      -   5        $ Account2??5<      	Manager67   5=      5>      ?? 5@   
   $??2??6   $??456,118,0,0q?5A      .+?5B      ?? -   5         ??Name$ AddClientButton??5B      $??Add new client??5C      $??61??5D      $??21(?5E      {?.  5G      5I      5J      5K      
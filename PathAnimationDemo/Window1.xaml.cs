﻿using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UntitledProject1
{
	public partial class Window1
	{
		public Window1()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           

        }

        private void Test_Double()
        {
            Canvas.SetTop(this.border1, -this.border1.ActualHeight / 2);
            Canvas.SetLeft(this.border1, -this.border1.ActualWidth / 2);

            this.border1.RenderTransformOrigin = new Point(0.5, 0.5);
        
            TranslateTransform translate = new TranslateTransform();
            RotateTransform rotate = new RotateTransform();
            TransformGroup group = new TransformGroup();
            group.Children.Add(rotate);//先旋转
            group.Children.Add(translate);//再平移
            this.border1.RenderTransform = group;

            NameScope.SetNameScope(this, new NameScope());
            this.RegisterName("translate", translate);
            this.RegisterName("rotate", rotate);

            DoubleAnimationUsingPath animationX = new DoubleAnimationUsingPath();
            animationX.PathGeometry = this.path1.Data.GetFlattenedPathGeometry();
            animationX.Source = PathAnimationSource.X;
            animationX.Duration = new Duration(TimeSpan.FromSeconds(2));

            DoubleAnimationUsingPath animationY = new DoubleAnimationUsingPath();
            animationY.PathGeometry = this.path1.Data.GetFlattenedPathGeometry();
            animationY.Source = PathAnimationSource.Y;
            animationY.Duration = animationX.Duration;

            DoubleAnimationUsingPath animationAngle = new DoubleAnimationUsingPath();
            animationAngle.PathGeometry = this.path1.Data.GetFlattenedPathGeometry();
            animationAngle.Source = PathAnimationSource.Angle;
            animationAngle.Duration = animationX.Duration;

            Storyboard story = new Storyboard();
            story.RepeatBehavior = RepeatBehavior.Forever;
            story.AutoReverse = true;
            story.Children.Add(animationX);
            story.Children.Add(animationY);
            story.Children.Add(animationAngle);
            Storyboard.SetTargetName(animationX, "translate");
            Storyboard.SetTargetName(animationY, "translate");
            Storyboard.SetTargetName(animationAngle, "rotate");
            Storyboard.SetTargetProperty(animationX, new PropertyPath(TranslateTransform.XProperty));
            Storyboard.SetTargetProperty(animationY, new PropertyPath(TranslateTransform.YProperty));
            Storyboard.SetTargetProperty(animationAngle, new PropertyPath(RotateTransform.AngleProperty));

            story.Begin(this);
        }

        private void Test_Matrix()
        {
            Canvas.SetLeft(this.border1, -this.border1.ActualWidth / 2);
            Canvas.SetTop(this.border1, -this.border1.ActualHeight / 2);
            this.border1.RenderTransformOrigin = new Point(0.5, 0.5);

            MatrixTransform matrix = new MatrixTransform();
            this.border1.RenderTransform = matrix;

            NameScope.SetNameScope(this, new NameScope());
            this.RegisterName("matrix", matrix);

            MatrixAnimationUsingPath matrixAnimation = new MatrixAnimationUsingPath();
            matrixAnimation.PathGeometry = this.path1.Data.GetFlattenedPathGeometry();
            matrixAnimation.Duration = new Duration(TimeSpan.FromSeconds(2));
            matrixAnimation.RepeatBehavior = RepeatBehavior.Forever;
            matrixAnimation.AutoReverse = true;
            matrixAnimation.IsOffsetCumulative = !matrixAnimation.AutoReverse;
            matrixAnimation.DoesRotateWithTangent = true;//旋转


            Storyboard story = new Storyboard();
            story.Children.Add(matrixAnimation);
            Storyboard.SetTargetName(matrixAnimation, "matrix");
            Storyboard.SetTargetProperty(matrixAnimation, new PropertyPath(MatrixTransform.MatrixProperty));
            story.Begin(this);
        }

        private void Test_Double2()
        {
            Canvas.SetTop(this.border1, -this.border1.ActualHeight / 2);
            Canvas.SetLeft(this.border1, -this.border1.ActualWidth / 2);
            this.border1.RenderTransformOrigin = new Point(0.5, 0.5);

            TranslateTransform translate = new TranslateTransform();
            this.border1.RenderTransform = translate;

            NameScope.SetNameScope(this, new NameScope());
            this.RegisterName("translate", translate);

            DoubleAnimationUsingPath animationX = new DoubleAnimationUsingPath();
            animationX.PathGeometry = this.path1.Data.GetFlattenedPathGeometry();
            animationX.Source = PathAnimationSource.X;
            animationX.Duration = new Duration(TimeSpan.FromSeconds(2));

            DoubleAnimationUsingPath animationY = new DoubleAnimationUsingPath();
            animationY.PathGeometry = this.path1.Data.GetFlattenedPathGeometry();
            animationY.Source = PathAnimationSource.Y;
            animationY.Duration = animationX.Duration;


            Storyboard story = new Storyboard();
            story.RepeatBehavior = RepeatBehavior.Forever;
            story.AutoReverse = true;
            story.Children.Add(animationX);
            story.Children.Add(animationY);
            Storyboard.SetTargetName(animationX, "translate");
            Storyboard.SetTargetName(animationY, "translate");
            Storyboard.SetTargetProperty(animationX, new PropertyPath(TranslateTransform.XProperty));
            Storyboard.SetTargetProperty(animationY, new PropertyPath(TranslateTransform.YProperty));

            story.Begin(this);
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            this.Test_Double();
           //this.Test_Matrix();
        }


       
	}
}
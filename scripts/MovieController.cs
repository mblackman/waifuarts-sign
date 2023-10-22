using Godot;

public partial class MovieController : Node
{
	[Export] private int _numLoops;
	
	private bool _isMovie;
	private AnimationPlayer _animationPlayer;
	private int _loopCount;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_isMovie = OS.HasFeature("movie");
		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		_animationPlayer.AnimationFinished += AnimationPlayerOnAnimationFinished;
	}

	private void AnimationPlayerOnAnimationFinished(StringName animname)
	{
		_loopCount++;

		if (_loopCount >= _numLoops)
		{
			if (_isMovie)
			{
				GetTree().Quit();
			}
		}
		else
		{
			_animationPlayer.Play();
		}
	}
}

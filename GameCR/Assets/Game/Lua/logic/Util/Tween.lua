DOTween				= DG.Tweening.DOTween
Tween             	= DG.Tweening.ShortcutExtensions
Tween46 			= DG.Tweening.ShortcutExtensions46
TweenExtension 		= DG.Tweening.TweenExtensions
TweenSetting		= DG.Tweening.TweenSettingsExtensions
ScrambleMode		= DG.Tweening.ScrambleMode
RotateMode			= DG.Tweening.RotateMode
CEase				= DG.Tweening.Ease

Ease = class("Ease", 
{
	Unset = CEase.Unset,
	Linear = CEase.Linear,
	InSine = CEase.InSine,
	OutSine = CEase.OutSine,
	InOutSine = CEase.InOutSine,
	InQuad = CEase.InQuad,
	OutQuad = CEase.OutQuad,
	InOutQuad = CEase.InOutQuad,
	InCubic = CEase.InCubic,
	OutCubic = CEase.OutCubic,
	InOutCubic = CEase.InOutCubic,
	InQuart = CEase.InQuart,
	OutQuart = CEase.OutQuart,
	InOutQuart = CEase.InOutQuart,
	InQuint = CEase.InQuint,
	OutQuint = CEase.OutQuint,
	InOutQuint = CEase.InOutQuint,
	InExpo = CEase.InExpo,
	OutExpo = CEase.OutExpo,
	InOutExpo = CEase.InOutExpo,
	InCirc = CEase.InCirc,
	OutCirc = CEase.OutCirc,
	InOutCirc = CEase.InOutCirc,
	InElastic = CEase.InElastic,
	OutElastic = CEase.OutElastic,
	InOutElastic = CEase.InOutElastic,
	InBack = CEase.InBack,
	OutBack = CEase.OutBack,
	InOutBack = CEase.InOutBack,
	InBounce = CEase.InBounce,
	OutBounce = CEase.OutBounce,
	InOutBounce = CEase.InOutBounce,
	INTERNAL_Zero = CEase.INTERNAL_Zero,
	INTERNAL_Custo = CEase.INTERNAL_Custom
})

-----------------------
--  Tweener
-----------------------

Tweener = class("Tweener", 
{
})

function Tweener.Kill(tweener, delay)
	TweenExtension.Kill(tweener, delay)
end

function Tweener.SetDelay(tweener, delay)
	return DOTweenLuaUtils.SetDelay(tweener, delay)
end

function Tweener.SetEase(tweener, easeFunc --[[Ease]])
	return DOTweenLuaUtils.SetEase(tweener, easeFunc)
end

function Tweener.SetLoop(tweener, loopCount)
	return DOTweenLuaUtils.SetLoop(tweener, loopCount)
end

function Tweener.SetOnComplete(tweener, callback)
	return DOTweenLuaUtils.OnTweenerComplete(tweener, callback)
end

function Tweener.SetOnUpdate(tweener, callback)
	return DOTweenLuaUtils.OnTweenerUpdate(tweener, callback)
end

function Tweener.PlayTween(tween)
	return DOTweenLuaUtils.PlayTween(tween)
end

function Tweener.PauseTween(tween)
	return DOTweenLuaUtils.PauseTween(tween)
end

--自定义Tween变化
function Tweener.TweenTo(getter, settter, endValue, duration)
	return DOTweenLuaUtils.TweenTo(getter, settter, endValue, duration)
end

function Tweener.DoTextNumber(text, targetValue, duration)
	return DOTweenLuaUtils.TweenTo(
		function() 
			return tonumber(text.text) 
		end, 
		function(val)
			text.text = math.floor(val)
		end, 
		targetValue, duration)
end

function Tweener.DOVisible(target, isVisible)
	return function()
		target.gameObject:SetActive(isVisible)
	end
end

function Tweener.DOAspect(target --[[Camera]], endValue --[[float]], duration --[[float]])
	return Tween.DOAspect(target, endValue, duration)
end

function Tweener.DOBlendableColor(target --[[Material]], endValue --[[Color]], property --[[string]], duration --[[float]])
	return Tween.DOBlendableColor(target, endValue, property, duration)
end

function Tweener.DOBlendableColor2(target --[[Light]], endValue --[[Color]], duration --[[float]])
	return Tween.DOBlendableColor(target, endValue, duration)
end

function Tweener.DOBlendableColor3(target --[[Material]], endValue --[[Color]], duration --[[float]])
	return Tween.DOBlendableColor(target, endValue, duration)
end

function Tweener.DOBlendableLocalMoveBy(target --[[Transform]], byValue --[[Vector3]], duration --[[float]], snapping --[[bool]])
	return Tween.DOBlendableLocalMoveBy(target, byValue, duration, snapping)
end

function Tweener.DOBlendableLocalRotateBy(target --[[Transform]], byValue --[[Vector3]], duration --[[float]], mode --[[RotateMode]])
	return Tween.DOBlendableLocalRotateBy(target, byValue, duration, mode)
end

function Tweener.DOBlendableMoveBy(target --[[Transform]], byValue --[[Vector3]], duration --[[float]], snapping --[[bool]])
	return Tween.DOBlendableMoveBy(target, byValue, duration, snapping)
end

function Tweener.DOBlendableRotateBy(target --[[Transform]], byValue --[[Vector3]], duration --[[float]], mode --[[RotateMode]])
	return Tween.DOBlendableRotateBy(target, byValue, duration, mode)
end

function Tweener.DOBlendableScaleBy(target --[[Transform]], byValue --[[Vector3]], duration --[[float]])
	return Tween.DOBlendableScaleBy(target, byValue, duration)
end

function Tweener.DOColor(target --[[Material]], endValue --[[Color]], duration --[[float]])
	return Tween.DOColor(target, endValue, duration)
end

function Tweener.DOColor2(target --[[Material]], endValue --[[Color]], property --[[string]], duration --[[float]])
	return Tween.DOColor(target, endValue, property, duration)
end

function Tweener.DOColor3(target --[[Light]], endValue --[[Color]], duration --[[float]])
	return Tween.DOColor(target, endValue, duration)
end

function Tweener.DOColor4(target --[[LineRenderer]], startValue --[[Color2]], endValue --[[Color2]], duration --[[float]])
	return Tween.DOColor(target, startValue, endValue, duration)
end

function Tweener.DOColor5(target --[[Camera]], endValue --[[Color]], duration --[[float]])
	return Tween.DOColor(target, endValue, duration)
end

function Tweener.DOComplete(target --[[Material]], withCallbacks --[[bool]])
	return Tween.DOComplete(target, withCallbacks)
end

function Tweener.DOComplete2(target --[[Component]], withCallbacks --[[bool]])
	return Tween.DOComplete(target, withCallbacks)
end

function Tweener.DOFade(target --[[Material]], endValue --[[float]], duration --[[float]])
	return Tween.DOFade(target, endValue, duration)
end

function Tweener.DOFade2(target --[[AudioSource]], endValue --[[float]], duration --[[float]])
	return Tween.DOFade(target, endValue, duration)
end

function Tweener.DOFade3(target --[[Material]], endValue --[[float]], property --[[string]], duration --[[float]])
	return Tween.DOFade(target, endValue, property, duration)
end

function Tweener.DOFarClipPlane(target --[[Camera]], endValue --[[float]], duration --[[float]])
	return Tween.DOFarClipPlane(target, endValue, duration)
end

function Tweener.DOFieldOfView(target --[[Camera]], endValue --[[float]], duration --[[float]])
	return Tween.DOFieldOfView(target, endValue, duration)
end

function Tweener.DOFlip(target --[[Material]])
	return Tween.DOFlip(target)
end

function Tweener.DOFlip2(target --[[Component]])
	return Tween.DOFlip(target)
end

function Tweener.DOFloat(target --[[Material]], endValue --[[float]], property --[[string]], duration --[[float]])
	return Tween.DOFloat(target, endValue, property, duration)
end

function Tweener.DOGoto(target --[[Material]], to --[[float]], andPlay --[[bool]])
	return Tween.DOGoto(target, to, andPlay)
end

function Tweener.DOGoto2(target --[[Component]], to --[[float]], andPlay --[[bool]])
	return Tween.DOGoto(target, to, andPlay)
end

function Tweener.DOIntensity(target --[[Light]], endValue --[[float]], duration --[[float]])
	return Tween.DOIntensity(target, endValue, duration)
end

function Tweener.DOJump(target --[[Transform]], endValue --[[Vector3]], jumpPower --[[float]], numJumps --[[int]], duration --[[float]], snapping --[[bool]])
	return Tween.DOJump(target, endValue, jumpPower, numJumps, duration, snapping)
end

function Tweener.DOJump2(target --[[Rigidbody]], endValue --[[Vector3]], jumpPower --[[float]], numJumps --[[int]], duration --[[float]], snapping --[[bool]])
	return Tween.DOJump(target, endValue, jumpPower, numJumps, duration, snapping)
end

function Tweener.DOKill(target --[[Component]], complete --[[bool]])
	return Tween.DOKill(target, complete)
end

function Tweener.DOKill2(target --[[Material]], complete --[[bool]])
	return Tween.DOKill(target, complete)
end

function Tweener.DOLocalJump(target --[[Transform]], endValue --[[Vector3]], jumpPower --[[float]], numJumps --[[int]], duration --[[float]], snapping --[[bool]])
	return Tween.DOLocalJump(target, endValue, jumpPower, numJumps, duration, snapping)
end

function Tweener.DOLocalMove(target --[[Transform]], endValue --[[Vector3]], duration --[[float]], snapping --[[bool]])
	return Tween.DOLocalMove(target, endValue, duration, snapping)
end

function Tweener.DOLocalMoveX(target --[[Transform]], endValue --[[float]], duration --[[float]], snapping --[[bool]])
	return Tween.DOLocalMoveX(target, endValue, duration, snapping)
end

function Tweener.DOLocalMoveY(target --[[Transform]], endValue --[[float]], duration --[[float]], snapping --[[bool]])
	return Tween.DOLocalMoveY(target, endValue, duration, snapping)
end

function Tweener.DOLocalMoveZ(target --[[Transform]], endValue --[[float]], duration --[[float]], snapping --[[bool]])
	return Tween.DOLocalMoveZ(target, endValue, duration, snapping)
end

function Tweener.DOLocalRotate(target --[[Transform]], endValue --[[Vector3]], duration --[[float]], mode --[[RotateMode]])
	return Tween.DOLocalRotate(target, endValue, duration, mode)
end

function Tweener.DOLookAt(target --[[Rigidbody]], towards --[[Vector3]], duration --[[float]], axisConstraint --[[AxisConstraint]], up --[[Vector3]])
	return Tween.DOLookAt(target, towards, duration, axisConstraint, up)
end

function Tweener.DOLookAt2(target --[[Transform]], towards --[[Vector3]], duration --[[float]], axisConstraint --[[AxisConstraint]], up --[[Vector3]])
	return Tween.DOLookAt(target, towards, duration, axisConstraint, up)
end

function Tweener.DOMove(target --[[Transform]], endValue --[[Vector3]], duration --[[float]], snapping --[[bool]])
	return Tween.DOMove(target, endValue, duration, snapping)
end

function Tweener.DOMove2(target --[[Rigidbody]], endValue --[[Vector3]], duration --[[float]], snapping --[[bool]])
	return Tween.DOMove(target, endValue, duration, snapping)
end

function Tweener.DOMoveX(target --[[Transform]], endValue --[[float]], duration --[[float]], snapping --[[bool]])
	return Tween.DOMoveX(target, endValue, duration, snapping)
end

function Tweener.DOMoveX2(target --[[Rigidbody]], endValue --[[float]], duration --[[float]], snapping --[[bool]])
	return Tween.DOMoveX(target, endValue, duration, snapping)
end

function Tweener.DOMoveY(target --[[Rigidbody]], endValue --[[float]], duration --[[float]], snapping --[[bool]])
	return Tween.DOMoveY(target, endValue, duration, snapping)
end

function Tweener.DOMoveY2(target --[[Transform]], endValue --[[float]], duration --[[float]], snapping --[[bool]])
	return Tween.DOMoveY(target, endValue, duration, snapping)
end

function Tweener.DOMoveZ(target --[[Transform]], endValue --[[float]], duration --[[float]], snapping --[[bool]])
	return Tween.DOMoveZ(target, endValue, duration, snapping)
end

function Tweener.DOMoveZ2(target --[[Rigidbody]], endValue --[[float]], duration --[[float]], snapping --[[bool]])
	return Tween.DOMoveZ(target, endValue, duration, snapping)
end

function Tweener.DONearClipPlane(target --[[Camera]], endValue --[[float]], duration --[[float]])
	return Tween.DONearClipPlane(target, endValue, duration)
end

function Tweener.DOOffset(target --[[Material]], endValue --[[Vector2]], property --[[string]], duration --[[float]])
	return Tween.DOOffset(target, endValue, property, duration)
end

function Tweener.DOOffset2(target --[[Material]], endValue --[[Vector2]], duration --[[float]])
	return Tween.DOOffset(target, endValue, duration)
end

function Tweener.DOOrthoSize(target --[[Camera]], endValue --[[float]], duration --[[float]])
	return Tween.DOOrthoSize(target, endValue, duration)
end

function Tweener.DOPause(target --[[Material]])
	return Tween.DOPause(target)
end

function Tweener.DOPause2(target --[[Component]])
	return Tween.DOPause(target)
end

function Tweener.DOPitch(target --[[AudioSource]], endValue --[[float]], duration --[[float]])
	return Tween.DOPitch(target, endValue, duration)
end

function Tweener.DOPixelRect(target --[[Camera]], endValue --[[Rect]], duration --[[float]])
	return Tween.DOPixelRect(target, endValue, duration)
end

function Tweener.DOPlay(target --[[Material]])
	return Tween.DOPlay(target)
end

function Tweener.DOPlay2(target --[[Component]])
	return Tween.DOPlay(target)
end

function Tweener.DOPlayBackwards(target --[[Material]])
	return Tween.DOPlayBackwards(target)
end

function Tweener.DOPlayBackwards2(target --[[Component]])
	return Tween.DOPlayBackwards(target)
end

function Tweener.DOPlayForward(target --[[Component]])
	return Tween.DOPlayForward(target)
end

function Tweener.DOPlayForward2(target --[[Material]])
	return Tween.DOPlayForward(target)
end

function Tweener.DOPunchPosition(target --[[Transform]], punch --[[Vector3]], duration --[[float]], vibrato --[[int]], elasticity --[[float]], snapping --[[bool]])
	return Tween.DOPunchPosition(target, punch, duration, vibrato, elasticity, snapping)
end

function Tweener.DOPunchRotation(target --[[Transform]], punch --[[Vector3]], duration --[[float]], vibrato --[[int]], elasticity --[[float]])
	return Tween.DOPunchRotation(target, punch, duration, vibrato, elasticity)
end

function Tweener.DOPunchScale(target --[[Transform]], punch --[[Vector3]], duration --[[float]], vibrato --[[int]], elasticity --[[float]])
	return Tween.DOPunchScale(target, punch, duration, vibrato, elasticity)
end

function Tweener.DORect(target --[[Camera]], endValue --[[Rect]], duration --[[float]])
	return Tween.DORect(target, endValue, duration)
end

function Tweener.DOResize(target --[[TrailRenderer]], toStartWidth --[[float]], toEndWidth --[[float]], duration --[[float]])
	return Tween.DOResize(target, toStartWidth, toEndWidth, duration)
end

function Tweener.DORestart(target --[[Material]], includeDelay --[[bool]])
	return Tween.DORestart(target, includeDelay)
end

function Tweener.DORestart2(target --[[Component]], includeDelay --[[bool]])
	return Tween.DORestart(target, includeDelay)
end

function Tweener.DORewind(target --[[Component]], includeDelay --[[bool]])
	return Tween.DORewind(target, includeDelay)
end

function Tweener.DORewind2(target --[[Material]], includeDelay --[[bool]])
	return Tween.DORewind(target, includeDelay)
end

function Tweener.DORotate(target --[[Rigidbody]], endValue --[[Vector3]], duration --[[float]], mode --[[RotateMode]])
	return Tween.DORotate(target, endValue, duration, mode)
end

function Tweener.DORotate2(target --[[Transform]], endValue --[[Vector3]], duration --[[float]], mode --[[RotateMode]])
	return Tween.DORotate(target, endValue, duration, mode)
end

function Tweener.DOScale(target --[[Transform]], endValue --[[float]], duration --[[float]])
	return Tween.DOScale(target, endValue, duration)
end

function Tweener.DOScale2(target --[[Transform]], endValue --[[Vector3]], duration --[[float]])
	return Tween.DOScale(target, endValue, duration)
end

function Tweener.DOScaleX(target --[[Transform]], endValue --[[float]], duration --[[float]])
	return Tween.DOScaleX(target, endValue, duration)
end

function Tweener.DOScaleY(target --[[Transform]], endValue --[[float]], duration --[[float]])
	return Tween.DOScaleY(target, endValue, duration)
end

function Tweener.DOScaleZ(target --[[Transform]], endValue --[[float]], duration --[[float]])
	return Tween.DOScaleZ(target, endValue, duration)
end

function Tweener.DOShadowStrength(target --[[Light]], endValue --[[float]], duration --[[float]])
	return Tween.DOShadowStrength(target, endValue, duration)
end

function Tweener.DOShakePosition(target --[[Camera]], duration --[[float]], strength --[[Vector3]], vibrato --[[int]], randomness --[[float]])
	return Tween.DOShakePosition(target, duration, strength, vibrato, randomness)
end

function Tweener.DOShakePosition2(target --[[Camera]], duration --[[float]], strength --[[float]], vibrato --[[int]], randomness --[[float]])
	return Tween.DOShakePosition(target, duration, strength, vibrato, randomness)
end

function Tweener.DOShakePosition3(target --[[Transform]], duration --[[float]], strength --[[float]], vibrato --[[int]], randomness --[[float]], snapping --[[bool]])
	return Tween.DOShakePosition(target, duration, strength, vibrato, randomness, snapping)
end

function Tweener.DOShakePosition4(target --[[Transform]], duration --[[float]], strength --[[Vector3]], vibrato --[[int]], randomness --[[float]], snapping --[[bool]])
	return Tween.DOShakePosition(target, duration, strength, vibrato, randomness, snapping)
end

function Tweener.DOShakeRotation(target --[[Camera]], duration --[[float]], strength --[[Vector3]], vibrato --[[int]], randomness --[[float]])
	return Tween.DOShakeRotation(target, duration, strength, vibrato, randomness)
end

function Tweener.DOShakeRotation2(target --[[Camera]], duration --[[float]], strength --[[float]], vibrato --[[int]], randomness --[[float]])
	return Tween.DOShakeRotation(target, duration, strength, vibrato, randomness)
end

function Tweener.DOShakeRotation3(target --[[Transform]], duration --[[float]], strength --[[float]], vibrato --[[int]], randomness --[[float]])
	return Tween.DOShakeRotation(target, duration, strength, vibrato, randomness)
end

function Tweener.DOShakeRotation4(target --[[Transform]], duration --[[float]], strength --[[Vector3]], vibrato --[[int]], randomness --[[float]])
	return Tween.DOShakeRotation(target, duration, strength, vibrato, randomness)
end

function Tweener.DOShakeScale(target --[[Transform]], duration --[[float]], strength --[[Vector3]], vibrato --[[int]], randomness --[[float]])
	return Tween.DOShakeScale(target, duration, strength, vibrato, randomness)
end

function Tweener.DOShakeScale2(target --[[Transform]], duration --[[float]], strength --[[float]], vibrato --[[int]], randomness --[[float]])
	return Tween.DOShakeScale(target, duration, strength, vibrato, randomness)
end

function Tweener.DOSmoothRewind(target --[[Material]])
	return Tween.DOSmoothRewind(target)
end

function Tweener.DOSmoothRewind2(target --[[Component]])
	return Tween.DOSmoothRewind(target)
end

function Tweener.DOTiling(target --[[Material]], endValue --[[Vector2]], duration --[[float]])
	return Tween.DOTiling(target, endValue, duration)
end

function Tweener.DOTiling2(target --[[Material]], endValue --[[Vector2]], property --[[string]], duration --[[float]])
	return Tween.DOTiling(target, endValue, property, duration)
end

function Tweener.DOTime(target --[[TrailRenderer]], endValue --[[float]], duration --[[float]])
	return Tween.DOTime(target, endValue, duration)
end

function Tweener.DOTogglePause(target --[[Material]])
	return Tween.DOTogglePause(target)
end

function Tweener.DOTogglePause2(target --[[Component]])
	return Tween.DOTogglePause(target)
end

function Tweener.DOVector(target --[[Material]], endValue --[[Vector4]], property --[[string]], duration --[[float]])
	return Tween.DOVector(target, endValue, property, duration)
end

function Tweener.DOAnchorPos(target --[[RectTransform]], endValue --[[Vector2]], duration --[[float]], snapping --[[bool]])
	return Tween46.DOAnchorPos(target, endValue, duration, snapping)
end

function Tweener.DOAnchorPos3D(target --[[RectTransform]], endValue --[[Vector3]], duration --[[float]], snapping --[[bool]])
	return Tween46.DOAnchorPos3D(target, endValue, duration, snapping)
end

function Tweener.DOBlendableColor(target --[[Graphic]], endValue --[[Color]], duration --[[float]])
	return Tween46.DOBlendableColor(target, endValue, duration)
end

function Tweener.DOBlendableColor2(target --[[Image]], endValue --[[Color]], duration --[[float]])
	return Tween46.DOBlendableColor(target, endValue, duration)
end

function Tweener.DOBlendableColor3(target --[[Text]], endValue --[[Color]], duration --[[float]])
	return Tween46.DOBlendableColor(target, endValue, duration)
end

function Tweener.DOColor(target --[[Outline]], endValue --[[Color]], duration --[[float]])
	return Tween46.DOColor(target, endValue, duration)
end

function Tweener.DOColor2(target --[[Graphic]], endValue --[[Color]], duration --[[float]])
	return Tween46.DOColor(target, endValue, duration)
end

function Tweener.DOColor3(target --[[Text]], endValue --[[Color]], duration --[[float]])
	return Tween46.DOColor(target, endValue, duration)
end

function Tweener.DOColor4(target --[[Image]], endValue --[[Color]], duration --[[float]])
	return Tween46.DOColor(target, endValue, duration)
end

function Tweener.DOFade(target --[[Graphic]], endValue --[[float]], duration --[[float]])
	return Tween46.DOFade(target, endValue, duration)
end

function Tweener.DOFade2(target --[[Text]], endValue --[[float]], duration --[[float]])
	return Tween46.DOFade(target, endValue, duration)
end

function Tweener.DOFade3(target --[[Image]], endValue --[[float]], duration --[[float]])
	return Tween46.DOFade(target, endValue, duration)
end

function Tweener.DOFade4(target --[[CanvasGroup]], endValue --[[float]], duration --[[float]])
	return Tween46.DOFade(target, endValue, duration)
end

function Tweener.DOFade5(target --[[Outline]], endValue --[[float]], duration --[[float]])
	return Tween46.DOFade(target, endValue, duration)
end

function Tweener.DOFillAmount(target --[[Image]], endValue --[[float]], duration --[[float]])
	return Tween46.DOFillAmount(target, endValue, duration)
end

function Tweener.DOFlexibleSize(target --[[LayoutElement]], endValue --[[Vector2]], duration --[[float]], snapping --[[bool]])
	return Tween46.DOFlexibleSize(target, endValue, duration, snapping)
end

function Tweener.DOJumpAnchorPos(target --[[RectTransform]], endValue --[[Vector2]], jumpPower --[[float]], numJumps --[[int]], duration --[[float]], snapping --[[bool]])
	return Tween46.DOJumpAnchorPos(target, endValue, jumpPower, numJumps, duration, snapping)
end

function Tweener.DOMinSize(target --[[LayoutElement]], endValue --[[Vector2]], duration --[[float]], snapping --[[bool]])
	return Tween46.DOMinSize(target, endValue, duration, snapping)
end

function Tweener.DOPreferredSize(target --[[LayoutElement]], endValue --[[Vector2]], duration --[[float]], snapping --[[bool]])
	return Tween46.DOPreferredSize(target, endValue, duration, snapping)
end

function Tweener.DOPunchAnchorPos(target --[[RectTransform]], punch --[[Vector2]], duration --[[float]], vibrato --[[int]], elasticity --[[float]], snapping --[[bool]])
	return Tween46.DOPunchAnchorPos(target, punch, duration, vibrato, elasticity, snapping)
end

function Tweener.DOScale3(target --[[Outline]], endValue --[[Vector2]], duration --[[float]])
	return Tween46.DOScale(target, endValue, duration)
end

function Tweener.DOShakeAnchorPos(target --[[RectTransform]], duration --[[float]], strength --[[Vector2]], vibrato --[[int]], randomness --[[float]], snapping --[[bool]])
	return Tween46.DOShakeAnchorPos(target, duration, strength, vibrato, randomness, snapping)
end

function Tweener.DOShakeAnchorPos2(target --[[RectTransform]], duration --[[float]], strength --[[float]], vibrato --[[int]], randomness --[[float]], snapping --[[bool]])
	return Tween46.DOShakeAnchorPos(target, duration, strength, vibrato, randomness, snapping)
end

function Tweener.DOSizeDelta(target --[[RectTransform]], endValue --[[Vector2]], duration --[[float]], snapping --[[bool]])
	return Tween46.DOSizeDelta(target, endValue, duration, snapping)
end

function Tweener.DOText(target --[[Text]], endValue --[[string]], duration --[[float]], richTextEnabled --[[bool]], scrambleMode --[[ScrambleMode]], scrambleChars --[[string]])
	return Tween46.DOText(target, endValue, duration, richTextEnabled, scrambleMode, scrambleChars)
end

function Tweener.DOValue(target --[[Slider]], endValue --[[float]], duration --[[float]], snapping --[[bool]])
	return Tween46.DOValue(target, endValue, duration, snapping)
end

--tweensetting

function Tweener.Complete(t --[[Tween]], withCallbacks --[[bool]])
	return TweenExtension.Complete(t, withCallbacks)
end

function Tweener.CompletedLoops(t --[[Tween]])
	return TweenExtension.CompletedLoops(t)
end

function Tweener.Delay(t --[[Tween]])
	return TweenExtension.Delay(t)
end

function Tweener.Duration(t --[[Tween]], includeLoops --[[bool]])
	return TweenExtension.Duration(t, includeLoops)
end

function Tweener.Elapsed(t --[[Tween]], includeLoops --[[bool]])
	return TweenExtension.Elapsed(t, includeLoops)
end

function Tweener.ElapsedDirectionalPercentage(t --[[Tween]])
	return TweenExtension.ElapsedDirectionalPercentage(t)
end

function Tweener.ElapsedPercentage(t --[[Tween]], includeLoops --[[bool]])
	return TweenExtension.ElapsedPercentage(t, includeLoops)
end

function Tweener.Flip(t --[[Tween]])
	return TweenExtension.Flip(t)
end

function Tweener.ForceInit(t --[[Tween]])
	return TweenExtension.ForceInit(t)
end

function Tweener.Goto(t --[[Tween]], to --[[float]], andPlay --[[bool]])
	return TweenExtension.Goto(t, to, andPlay)
end

function Tweener.GotoWaypoint(t --[[Tween]], waypointIndex --[[int]], andPlay --[[bool]])
	return TweenExtension.GotoWaypoint(t, waypointIndex, andPlay)
end

function Tweener.IsActive(t --[[Tween]])
	return TweenExtension.IsActive(t)
end

function Tweener.IsBackwards(t --[[Tween]])
	return TweenExtension.IsBackwards(t)
end

function Tweener.IsComplete(t --[[Tween]])
	return TweenExtension.IsComplete(t)
end

function Tweener.IsInitialized(t --[[Tween]])
	return TweenExtension.IsInitialized(t)
end

function Tweener.IsPlaying(t --[[Tween]])
	return TweenExtension.IsPlaying(t)
end

function Tweener.Kill(t --[[Tween]], complete --[[bool]])
	return TweenExtension.Kill(t, complete)
end

function Tweener.Loops(t --[[Tween]])
	return TweenExtension.Loops(t)
end

function Tweener.PathGetPoint(t --[[Tween]], pathPercentage --[[float]])
	return TweenExtension.PathGetPoint(t, pathPercentage)
end

function Tweener.PathLength(t --[[Tween]])
	return TweenExtension.PathLength(t)
end

function Tweener.PlayBackwards(t --[[Tween]])
	return TweenExtension.PlayBackwards(t)
end

function Tweener.PlayForward(t --[[Tween]])
	return TweenExtension.PlayForward(t)
end

function Tweener.Restart(t --[[Tween]], includeDelay --[[bool]])
	return TweenExtension.Restart(t, includeDelay)
end

function Tweener.Rewind(t --[[Tween]], includeDelay --[[bool]])
	return TweenExtension.Rewind(t, includeDelay)
end

function Tweener.SmoothRewind(t --[[Tween]])
	return TweenExtension.SmoothRewind(t)
end

function Tweener.TogglePause(t --[[Tween]])
	return TweenExtension.TogglePause(t)
end

function Tweener.WaitForCompletion(t --[[Tween]])
	return TweenExtension.WaitForCompletion(t)
end

function Tweener.WaitForElapsedLoops(t --[[Tween]], elapsedLoops --[[int]])
	return TweenExtension.WaitForElapsedLoops(t, elapsedLoops)
end

function Tweener.WaitForKill(t --[[Tween]])
	return TweenExtension.WaitForKill(t)
end

function Tweener.WaitForPosition(t --[[Tween]], position --[[float]])
	return TweenExtension.WaitForPosition(t, position)
end

function Tweener.WaitForRewind(t --[[Tween]])
	return TweenExtension.WaitForRewind(t)
end

function Tweener.WaitForStart(t --[[Tween]])
	return TweenExtension.WaitForStart(t)
end

-----------------------
--  Sequence
-----------------------

Sequence = class("Sequence")

function Sequence:ctor()
	self.tweenSeq = DOTween.Sequence()
end

--传入函数（回调），时间（延迟），Tweener, table(Tweener并行执行)的多参
function Sequence:AppendInner(...)
	local arr = {...}
	for k,v in pairs(arr) do
		local err = false
		if type(v) == "function" then
			DOTweenLuaUtils.AppendSeqCallback(self.tweenSeq, v)
		elseif type(v) == "number" then
			TweenSetting.AppendInterval(self.tweenSeq, v)
		elseif type(v) == "userdata" then
			TweenSetting.Append(self.tweenSeq, v)
		elseif type(v) == "table" then
			for i0,v0 in ipairs(v) do
				if i0 == 1 then
					if type(v0) == "userdata" then
						TweenSetting.Append(self.tweenSeq, v0)
					elseif type(v0) == "table" then
						TweenSetting.Append(self.tweenSeq, v0.tweenSeq)
					end
				else
					if type(v0) == "userdata" then
						TweenSetting.Join(self.tweenSeq, v0)
					elseif type(v0) == "table" then
						TweenSetting.Join(self.tweenSeq, v0.tweenSeq)
					end
				end
			end
		else
			err = true
		end

		if err then
			error("DOTween Sequence Error : type " + type(v) + "not support")
		end
	end
end

function Sequence.Create(...)--[return:Sequence]
	local seq = Sequence.New()
	seq:AppendInner(...)

	return seq
end

function Sequence.CreateWithArray(arr)--[return:Sequence]
	return Sequence.Create(unpack(arr))
end
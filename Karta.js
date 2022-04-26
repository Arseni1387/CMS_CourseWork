(function (cjs, an) {

var p; // shortcut to reference prototypes
var lib={};var ss={};var img={};
lib.ssMetadata = [];


(lib.AnMovieClip = function(){
	this.currentSoundStreamInMovieclip;
	this.actionFrames = [];
	this.soundStreamDuration = new Map();
	this.streamSoundSymbolsList = [];

	this.gotoAndPlayForStreamSoundSync = function(positionOrLabel){
		cjs.MovieClip.prototype.gotoAndPlay.call(this,positionOrLabel);
	}
	this.gotoAndPlay = function(positionOrLabel){
		this.clearAllSoundStreams();
		this.startStreamSoundsForTargetedFrame(positionOrLabel);
		cjs.MovieClip.prototype.gotoAndPlay.call(this,positionOrLabel);
	}
	this.play = function(){
		this.clearAllSoundStreams();
		this.startStreamSoundsForTargetedFrame(this.currentFrame);
		cjs.MovieClip.prototype.play.call(this);
	}
	this.gotoAndStop = function(positionOrLabel){
		cjs.MovieClip.prototype.gotoAndStop.call(this,positionOrLabel);
		this.clearAllSoundStreams();
	}
	this.stop = function(){
		cjs.MovieClip.prototype.stop.call(this);
		this.clearAllSoundStreams();
	}
	this.startStreamSoundsForTargetedFrame = function(targetFrame){
		for(var index=0; index<this.streamSoundSymbolsList.length; index++){
			if(index <= targetFrame && this.streamSoundSymbolsList[index] != undefined){
				for(var i=0; i<this.streamSoundSymbolsList[index].length; i++){
					var sound = this.streamSoundSymbolsList[index][i];
					if(sound.endFrame > targetFrame){
						var targetPosition = Math.abs((((targetFrame - sound.startFrame)/lib.properties.fps) * 1000));
						var instance = playSound(sound.id);
						var remainingLoop = 0;
						if(sound.offset){
							targetPosition = targetPosition + sound.offset;
						}
						else if(sound.loop > 1){
							var loop = targetPosition /instance.duration;
							remainingLoop = Math.floor(sound.loop - loop);
							if(targetPosition == 0){ remainingLoop -= 1; }
							targetPosition = targetPosition % instance.duration;
						}
						instance.loop = remainingLoop;
						instance.position = Math.round(targetPosition);
						this.InsertIntoSoundStreamData(instance, sound.startFrame, sound.endFrame, sound.loop , sound.offset);
					}
				}
			}
		}
	}
	this.InsertIntoSoundStreamData = function(soundInstance, startIndex, endIndex, loopValue, offsetValue){ 
 		this.soundStreamDuration.set({instance:soundInstance}, {start: startIndex, end:endIndex, loop:loopValue, offset:offsetValue});
	}
	this.clearAllSoundStreams = function(){
		var keys = this.soundStreamDuration.keys();
		for(var i = 0;i<this.soundStreamDuration.size; i++){
			var key = keys.next().value;
			key.instance.stop();
		}
 		this.soundStreamDuration.clear();
		this.currentSoundStreamInMovieclip = undefined;
	}
	this.stopSoundStreams = function(currentFrame){
		if(this.soundStreamDuration.size > 0){
			var keys = this.soundStreamDuration.keys();
			for(var i = 0; i< this.soundStreamDuration.size ; i++){
				var key = keys.next().value; 
				var value = this.soundStreamDuration.get(key);
				if((value.end) == currentFrame){
					key.instance.stop();
					if(this.currentSoundStreamInMovieclip == key) { this.currentSoundStreamInMovieclip = undefined; }
					this.soundStreamDuration.delete(key);
				}
			}
		}
	}

	this.computeCurrentSoundStreamInstance = function(currentFrame){
		if(this.currentSoundStreamInMovieclip == undefined){
			if(this.soundStreamDuration.size > 0){
				var keys = this.soundStreamDuration.keys();
				var maxDuration = 0;
				for(var i=0;i<this.soundStreamDuration.size;i++){
					var key = keys.next().value;
					var value = this.soundStreamDuration.get(key);
					if(value.end > maxDuration){
						maxDuration = value.end;
						this.currentSoundStreamInMovieclip = key;
					}
				}
			}
		}
	}
	this.getDesiredFrame = function(currentFrame, calculatedDesiredFrame){
		for(var frameIndex in this.actionFrames){
			if((frameIndex > currentFrame) && (frameIndex < calculatedDesiredFrame)){
				return frameIndex;
			}
		}
		return calculatedDesiredFrame;
	}

	this.syncStreamSounds = function(){
		this.stopSoundStreams(this.currentFrame);
		this.computeCurrentSoundStreamInstance(this.currentFrame);
		if(this.currentSoundStreamInMovieclip != undefined){
			var soundInstance = this.currentSoundStreamInMovieclip.instance;
			if(soundInstance.position != 0){
				var soundValue = this.soundStreamDuration.get(this.currentSoundStreamInMovieclip);
				var soundPosition = (soundValue.offset?(soundInstance.position - soundValue.offset): soundInstance.position);
				var calculatedDesiredFrame = (soundValue.start)+((soundPosition/1000) * lib.properties.fps);
				if(soundValue.loop > 1){
					calculatedDesiredFrame +=(((((soundValue.loop - soundInstance.loop -1)*soundInstance.duration)) / 1000) * lib.properties.fps);
				}
				calculatedDesiredFrame = Math.floor(calculatedDesiredFrame);
				var deltaFrame = calculatedDesiredFrame - this.currentFrame;
				if(deltaFrame >= 2){
					this.gotoAndPlayForStreamSoundSync(this.getDesiredFrame(this.currentFrame,calculatedDesiredFrame));
				}
			}
		}
	}
}).prototype = p = new cjs.MovieClip();
// symbols:



(lib.Растровоеизображение1 = function() {
	this.initialize(img.Растровоеизображение1);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,1600,1200);


(lib.Upr_block = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// timeline functions:
	this.frame_2 = function() {
		playSound("Blockwav");
	}
	this.frame_3 = function() {
		playSound("Blockwav");
	}

	// actions tween:
	this.timeline.addTween(cjs.Tween.get(this).wait(2).call(this.frame_2).wait(1).call(this.frame_3).wait(1));

	// Слой_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("rgba(255,255,0,0.2)").s().p("A7LT0Ilo/HIBIogMA4vAAAIHwMAIAAbngAjzibID/LHISQAAIlYrfgApzkzIaXAAImosoI3HAAg");
	this.shape.setTransform(-1.6,-34);

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("rgba(102,204,0,0.2)").s().p("A7LT0Ilo/HIBIogMA4vAAAIHwMAIAAbngAjzibID/LHISQAAIlYrfgApzkzIaXAAImosoI3HAAg");
	this.shape_1.setTransform(-1.6,-34);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[]}).to({state:[{t:this.shape}]},1).to({state:[{t:this.shape}]},1).to({state:[{t:this.shape_1}]},1).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-211.6,-160.8,420,253.60000000000002);


(lib.Rab_block = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// timeline functions:
	this.frame_2 = function() {
		playSound("Rab_blockwav");
	}
	this.frame_3 = function() {
		playSound("Rab_blockwav");
	}

	// actions tween:
	this.timeline.addTween(cjs.Tween.get(this).wait(2).call(this.frame_2).wait(1).call(this.frame_3).wait(1));

	// Слой_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("rgba(255,255,0,0.2)").s().p("A7YRDIlvy6IgRmSINmo5MA1MAAAMAAAAiFgA5fpvMAorAAAICBlzMghgAAAg");
	this.shape.setTransform(80,24.425);

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("rgba(102,204,0,0.2)").s().p("A7YRDIlvy6IgRmSINmo5MA1MAAAMAAAAiFgA5fpvMAorAAAICBlzMghgAAAg");
	this.shape_1.setTransform(80,24.425);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[]}).to({state:[{t:this.shape}]},1).to({state:[{t:this.shape}]},1).to({state:[{t:this.shape_1}]},1).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-133.7,-84.7,427.5,218.3);


(lib.Lat_st = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// timeline functions:
	this.frame_2 = function() {
		playSound("Lat_stakanwav");
	}
	this.frame_3 = function() {
		playSound("Lat_stakanwav");
	}

	// actions tween:
	this.timeline.addTween(cjs.Tween.get(this).wait(2).call(this.frame_2).wait(1).call(this.frame_3).wait(1));

	// Слой_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("rgba(255,255,0,0.2)").s().p("A52GLIJisVMAqLAAAIiMMVg");
	this.shape.setTransform(-46.025,-6.7);

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("rgba(102,204,0,0.2)").s().p("A52GLIJisVMAqLAAAIiMMVg");
	this.shape_1.setTransform(-46.025,-6.7);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[]}).to({state:[{t:this.shape}]},1).to({state:[{t:this.shape}]},1).to({state:[{t:this.shape_1}]},1).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-211.5,-46.2,331,79);


(lib.Krishka = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// timeline functions:
	this.frame_2 = function() {
		playSound("Crishkawav");
	}
	this.frame_3 = function() {
		playSound("Crishkawav");
	}

	// actions tween:
	this.timeline.addTween(cjs.Tween.get(this).wait(2).call(this.frame_2).wait(1).call(this.frame_3).wait(1));

	// Слой_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("rgba(255,255,0,0.2)").s().p("A7fJTIgep2IKysLMAtJACWIlAVZIiCAAIAABug");
	this.shape.setTransform(0,0.5);

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("rgba(102,153,0,0.2)").s().p("A7fJTIgep2IKysLMAtJACWIlAVZIiCAAIAABug");
	this.shape_1.setTransform(0,0.5);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[]}).to({state:[{t:this.shape}]},1).to({state:[{t:this.shape}]},1).to({state:[{t:this.shape_1}]},1).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-179,-81,358,163);


(lib.Ekran = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// timeline functions:
	this.frame_2 = function() {
		playSound("Ecranwav");
	}
	this.frame_3 = function() {
		playSound("Ecranwav");
	}

	// actions tween:
	this.timeline.addTween(cjs.Tween.get(this).wait(2).call(this.frame_2).wait(1).call(this.frame_3).wait(1));

	// Слой_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("rgba(255,255,0,0.2)").s().p("ApFFAIi6p/ISyADIFNJ8g");
	this.shape.setTransform(-150.875,-5.4);

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("rgba(102,204,0,0.2)").s().p("ApFFAIi6p/ISyADIFNJ8g");
	this.shape_1.setTransform(-150.875,-5.4);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[]}).to({state:[{t:this.shape}]},1).to({state:[{t:this.shape}]},1).to({state:[{t:this.shape_1}]},1).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-227.7,-37.4,227.7,64);


(lib.Clava = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// timeline functions:
	this.frame_2 = function() {
		playSound("Clavawav");
	}
	this.frame_3 = function() {
		playSound("Clavawav");
	}

	// actions tween:
	this.timeline.addTween(cjs.Tween.get(this).wait(2).call(this.frame_2).wait(1).call(this.frame_3).wait(1));

	// Слой_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("rgba(255,255,0,0.2)").s().p("AlkEWIi8oeINBgNIEAIrg");
	this.shape.setTransform(-9.725,10.025);

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("rgba(102,204,0,0.2)").s().p("AlkEWIi8oeINBgNIEAIrg");
	this.shape_1.setTransform(-9.725,10.025);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[]}).to({state:[{t:this.shape}]},1).to({state:[{t:this.shape}]},1).to({state:[{t:this.shape_1}]},1).wait(1));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-64.2,-17.7,109,55.5);


(lib.Al_st = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	// timeline functions:
	this.frame_2 = function() {
		playSound("Al_stakanwav");
	}
	this.frame_3 = function() {
		playSound("Al_stakanwav");
	}

	// actions tween:
	this.timeline.addTween(cjs.Tween.get(this).wait(2).call(this.frame_2).wait(1).call(this.frame_3).wait(1));

	// Слой_1
	this.shape = new cjs.Shape();
	this.shape.graphics.f("rgba(255,255,0,0.2)").s().p("AuDmFMAqfAAAIqKL3MgutAAUg");
	this.shape.setTransform(0.025,0.5);
	this.shape._off = true;

	this.timeline.addTween(cjs.Tween.get(this.shape).wait(1).to({_off:false},0).wait(3));

	this._renderFirstFrame();

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-181.9,-38.5,363.9,78);


// stage content:
(lib.Karta = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{});

	this.actionFrames = [0];
	this.isSingleFrame = false;
	// timeline functions:
	this.frame_0 = function() {
		if(this.isSingleFrame) {
			return;
		}
		if(this.totalFrames == 1) {
			this.isSingleFrame = true;
		}
		this.clearAllSoundStreams();
		 
	}

	// actions tween:
	this.timeline.addTween(cjs.Tween.get(this).call(this.frame_0).wait(1));

	// Слой_2
	this.shape = new cjs.Shape();
	this.shape.graphics.f("#000000").s().p("AgeA0QAGgRAQgbQAOgaANgTIg8AAIAAgOIBTAAIAAAGIgMASIgLAUIgNAVIgJAVIgHARg");
	this.shape.setTransform(704.65,305.575);

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.f("#000000").s().p("AgnAIQAAgRARgUQAQgUASgEIAIAIQgIADgNAOQgPAOgBAHQAHgFAMAAQARAAAKAJQALAHgBAPQAAAQgKAJQgKAJgQAAQgqAAAAgtgAgUATQAAAXAWAAQAJgBAGgFQAEgGAAgKQAAgJgFgGQgGgFgJAAQgVAAAAATg");
	this.shape_1.setTransform(544.7,267.8);

	this.shape_2 = new cjs.Shape();
	this.shape_2.graphics.f("#000000").s().p("AAPA0IAAgcIg6AAIAAgIIBEhDIAHAAIAABAIAMAAIAAALIgMAAIAAAcgAgWANIAlAAIAAgkg");
	this.shape_2.setTransform(96.9,189.125);

	this.shape_3 = new cjs.Shape();
	this.shape_3.graphics.f("#000000").s().p("AgjAsIAGgMQAMAJALAAQAYAAAAgaQAAgWgXABQgMAAgJAGIgGgCIAAgxIA+AAIAAAMIguAAIAAAZQAHgFAJAAQASABAJAIQAJAJAAAPQAAAngqgBQgSABgLgJg");
	this.shape_3.setTransform(342.875,195.65);

	this.shape_4 = new cjs.Shape();
	this.shape_4.graphics.f("#000000").s().p("AgWAzQgIgDgGgEIAJgKQAIAHAOAAQAXAAAAgTQAAgJgHgFQgHgGgLAAIgCAAIAAgKIABAAQAWAAAAgQQAAgQgUAAQgLAAgIAGIgHgKQAIgIATAAQAQAAALAHQAKAHAAAMQAAAIgGAHQgGAGgHADQAKACAHAGQAHAHgBAKQAAAPgLAHQgLAIgTAAQgJAAgIgCg");
	this.shape_4.setTransform(382.3,409.625);

	this.shape_5 = new cjs.Shape();
	this.shape_5.graphics.f("#000000").s().p("AgmA0IAAgDIAngwQANgQAAgKQAAgPgTAAQgIAAgGADQgFADgEAFIgLgIQADgGAJgEQAIgFANABQARgBALAIQALAGAAANQgBALgOARIgbAlIAxAAIAAAMg");
	this.shape_5.setTransform(541.5,349.3);

	this.shape_6 = new cjs.Shape();
	this.shape_6.graphics.f("#000000").s().p("AAEA0IAAhOIgZANIAAgNQAKgEALgHQALgHAGgHIAFAAIAABng");
	this.shape_6.setTransform(421.275,317.575);

	this.shape_7 = new cjs.Shape();
	this.shape_7.graphics.f().s("#000000").ss(3,1,1).p("EAtvABRQAxgaA9AAQBTAAA5AuQA7AvAABCQAABBg7AvQg5AvhTAAQhRAAg7gvQg5gvAAhBQAAhCA5gvQAOgLAQgJgEAufAA3IkXmrAq3v2QAygeBDAAQBSAAA6AuQA6AvAABCQAABBg6AvQg6AvhSAAQhSAAg6gvQg4gtgCg+QAAgDAAgCQAAgIAAgHQAGg4A0gqQALgJAMgHIptmOACMC5QAigKAnAAQBSAAA6AuQA6AvAABCQAABBg6AvQg6AvhSAAQhSAAg6gvQg6gvAAhBQAAhCA6gvQAegYAlgMIiQk5AYYkiQAKAGAKAIQA6AvAABBQAABCg6AvQg7AuhRAAQhTAAg5guQg7gvAAhCQAAhBA7gvQA5gvBTAAQBEAAA0AhIHunxAXFH2QAoALAhAaQA6AvAABCQAAAwggAmQgKAOgQAMQg6AvhSAAQhSAAg6gvQgPgMgLgOQgggmAAgwQAAhCA6gvQA6guBSAAQAkAAAfAJIDqlLEguUgRKQAlALAfAZQA6AuAABCQAAAmgTAgQgPAXgYAUQg6AuhSAAQhSAAg6guQgZgUgOgXQgUggAAgmQAAhCA7guQA6gvBSAAQAmAAAiALID9kvAlgSUQAMgQASgOQA6gvBSAAQBSAAA6AvQA5AuAABCQAABCg5AuQg6AvhSAAQhSAAg6gvQg6guAAhCQAAguAcgkIr0jm");
	this.shape_7.setTransform(401.4,283.975);

	this.shape_8 = new cjs.Shape();
	this.shape_8.graphics.f("#FFFFFF").s().p("AlCS/Qg6gvAAhCQAAgtAcglQANgQARgOQA6gvBSAAQBSAAA6AvQA6AvgBBBQABBCg6AvQg6AuhSAAQhSAAg6gugAT2JkQgPgMgLgNQgggmAAgxQAAhCA6guQA6gvBSAAQAkAAAgAJQAoALAgAbQA6AuAABCQAAAxgfAmQgMANgPAMQg6AvhSAAQhSAAg6gvgABKEmQg7guAAhCQAAhCA7guQAdgYAlgMQAigLAnAAQBSAAA7AvQA5AuAABCQAABCg5AuQg7AvhSAAQhSAAg5gvgEAtRACvQg6gvAAhCQAAhBA6guQAOgMARgIQAwgbA9AAQBSAAA7AvQA5AuABBBQgBBCg5AvQg7AuhSAAQhRAAg7gugAUUjLQg6gugBhCQABhCA6guQA5gvBSAAQBFAAA0AgIAUAPQA6AuAABCQAABCg6AuQg7AvhSAAQhSAAg5gvgArOucQg4gtgCg/IAAgFIAAgOQAHg5AzgpQALgJAMgHQAygfBDAAQBSAAA6AvQA6AuAABCQAABCg6AvQg6AuhSAAQhSAAg6gugEgxogPdQgZgUgOgXQgUgfAAgmQABhCA6gvQA6guBSAAQAmAAAiAKQAlAMAfAYQA6AvAABCQAAAmgTAfQgPAXgYAUQg6AvhSAAQhSAAg6gvg");
	this.shape_8.setTransform(401.4,299.125);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape_8},{t:this.shape_7},{t:this.shape_6},{t:this.shape_5},{t:this.shape_4},{t:this.shape_3},{t:this.shape_2},{t:this.shape_1},{t:this.shape}]}).wait(1));

	// Слой_1
	this.instance = new lib.Clava();
	this.instance.setTransform(679.3,243.95,1.0201,0.836,0,0,0,0.1,0.1);
	new cjs.ButtonHelper(this.instance, 0, 1, 2, false, new lib.Clava(), 3);

	this.instance_1 = new lib.Ekran();
	this.instance_1.setTransform(785.65,197.6,0.9669,0.8028,0,0,0,0.4,0.1);
	new cjs.ButtonHelper(this.instance_1, 0, 1, 2, false, new lib.Ekran(), 3);

	this.instance_2 = new lib.Upr_block();
	this.instance_2.setTransform(633.05,262.2,0.8012,0.6537,0,0,0,0.1,0.1);
	new cjs.ButtonHelper(this.instance_2, 0, 1, 2, false, new lib.Upr_block(), 3);

	this.instance_3 = new lib.Al_st();
	this.instance_3.setTransform(143.2,141.4,0.3165,0.2541,0,0,0,0.3,0);
	new cjs.ButtonHelper(this.instance_3, 0, 1, 2, false, new lib.Al_st(), 3);

	this.instance_4 = new lib.Lat_st();
	this.instance_4.setTransform(269.75,142.7,0.3335,0.2677,0,0,0,0.1,0.2);
	new cjs.ButtonHelper(this.instance_4, 0, 1, 2, false, new lib.Lat_st(), 3);

	this.instance_5 = new lib.Rab_block();
	this.instance_5.setTransform(131.5,181.95,0.9822,0.7883,0,0,0,0.2,0.1);
	new cjs.ButtonHelper(this.instance_5, 0, 1, 2, false, new lib.Rab_block(), 3);

	this.instance_6 = new lib.Krishka();
	this.instance_6.setTransform(173.45,370.25,1.0037,0.8055,0,0,0,0.4,0.2);
	new cjs.ButtonHelper(this.instance_6, 0, 1, 2, false, new lib.Krishka(), 3);

	this.instance_7 = new lib.Растровоеизображение1();
	this.instance_7.setTransform(0,0,0.4984,0.4);

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.instance_7},{t:this.instance_6},{t:this.instance_5},{t:this.instance_4},{t:this.instance_3},{t:this.instance_2},{t:this.instance_1},{t:this.instance}]}).wait(1));

	this._renderFirstFrame();

}).prototype = p = new lib.AnMovieClip();
p.nominalBounds = new cjs.Rectangle(393.4,240,406.5,240);
// library properties:
lib.properties = {
	id: '845C2B49D618A04C81D139BDB26011AA',
	width: 800,
	height: 480,
	fps: 30,
	color: "#FFFFFF",
	opacity: 1.00,
	manifest: [
		{src:"images/Растровоеизображение1.png?1635151260754", id:"Растровоеизображение1"},
		{src:"sounds/Al_stakanwav.mp3?1635151260754", id:"Al_stakanwav"},
		{src:"sounds/Clavawav.mp3?1635151260754", id:"Clavawav"},
		{src:"sounds/Lat_stakanwav.mp3?1635151260754", id:"Lat_stakanwav"},
		{src:"sounds/Rab_blockwav.mp3?1635151260754", id:"Rab_blockwav"},
		{src:"sounds/Ecranwav.mp3?1635151260754", id:"Ecranwav"},
		{src:"sounds/Blockwav.mp3?1635151260754", id:"Blockwav"},
		{src:"sounds/Crishkawav.mp3?1635151260754", id:"Crishkawav"}
	],
	preloads: []
};



// bootstrap callback support:

(lib.Stage = function(canvas) {
	createjs.Stage.call(this, canvas);
}).prototype = p = new createjs.Stage();

p.setAutoPlay = function(autoPlay) {
	this.tickEnabled = autoPlay;
}
p.play = function() { this.tickEnabled = true; this.getChildAt(0).gotoAndPlay(this.getTimelinePosition()) }
p.stop = function(ms) { if(ms) this.seek(ms); this.tickEnabled = false; }
p.seek = function(ms) { this.tickEnabled = true; this.getChildAt(0).gotoAndStop(lib.properties.fps * ms / 1000); }
p.getDuration = function() { return this.getChildAt(0).totalFrames / lib.properties.fps * 1000; }

p.getTimelinePosition = function() { return this.getChildAt(0).currentFrame / lib.properties.fps * 1000; }

an.bootcompsLoaded = an.bootcompsLoaded || [];
if(!an.bootstrapListeners) {
	an.bootstrapListeners=[];
}

an.bootstrapCallback=function(fnCallback) {
	an.bootstrapListeners.push(fnCallback);
	if(an.bootcompsLoaded.length > 0) {
		for(var i=0; i<an.bootcompsLoaded.length; ++i) {
			fnCallback(an.bootcompsLoaded[i]);
		}
	}
};

an.compositions = an.compositions || {};
an.compositions['845C2B49D618A04C81D139BDB26011AA'] = {
	getStage: function() { return exportRoot.stage; },
	getLibrary: function() { return lib; },
	getSpriteSheet: function() { return ss; },
	getImages: function() { return img; }
};

an.compositionLoaded = function(id) {
	an.bootcompsLoaded.push(id);
	for(var j=0; j<an.bootstrapListeners.length; j++) {
		an.bootstrapListeners[j](id);
	}
}

an.getComposition = function(id) {
	return an.compositions[id];
}


an.makeResponsive = function(isResp, respDim, isScale, scaleType, domContainers) {		
	var lastW, lastH, lastS=1;		
	window.addEventListener('resize', resizeCanvas);		
	resizeCanvas();		
	function resizeCanvas() {			
		var w = lib.properties.width, h = lib.properties.height;			
		var iw = window.innerWidth, ih=window.innerHeight;			
		var pRatio = window.devicePixelRatio || 1, xRatio=iw/w, yRatio=ih/h, sRatio=1;			
		if(isResp) {                
			if((respDim=='width'&&lastW==iw) || (respDim=='height'&&lastH==ih)) {                    
				sRatio = lastS;                
			}				
			else if(!isScale) {					
				if(iw<w || ih<h)						
					sRatio = Math.min(xRatio, yRatio);				
			}				
			else if(scaleType==1) {					
				sRatio = Math.min(xRatio, yRatio);				
			}				
			else if(scaleType==2) {					
				sRatio = Math.max(xRatio, yRatio);				
			}			
		}			
		domContainers[0].width = w * pRatio * sRatio;			
		domContainers[0].height = h * pRatio * sRatio;			
		domContainers.forEach(function(container) {				
			container.style.width = w * sRatio + 'px';				
			container.style.height = h * sRatio + 'px';			
		});			
		stage.scaleX = pRatio*sRatio;			
		stage.scaleY = pRatio*sRatio;			
		lastW = iw; lastH = ih; lastS = sRatio;            
		stage.tickOnUpdate = false;            
		stage.update();            
		stage.tickOnUpdate = true;		
	}
}
an.handleSoundStreamOnTick = function(event) {
	if(!event.paused){
		var stageChild = stage.getChildAt(0);
		if(!stageChild.paused){
			stageChild.syncStreamSounds();
		}
	}
}


})(createjs = createjs||{}, AdobeAn = AdobeAn||{});
var createjs, AdobeAn;
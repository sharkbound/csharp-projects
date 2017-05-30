def fib():
	cur,next = 0,1
	while 1:
		yield cur
		cur,next = cur + next, cur

		
def fib_at(n):
	cur,next = 0,1
	for _ in range(n):
		cur,next = cur + next, cur
	return cur

print(fib_at(200_000))
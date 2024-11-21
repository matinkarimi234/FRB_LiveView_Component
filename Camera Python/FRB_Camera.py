import time
import cv2


cap = cv2.VideoCapture(0)

cap.set(cv2.CAP_PROP_FRAME_WIDTH, 2592)

cap.set(cv2.CAP_PROP_FRAME_HEIGHT, 1944)

time.sleep(2)

#cap.set(cv2.CAP_PROP_EXPOSURE, -8.0)
cap.set(cv2.CAP_PROP_AUTOFOCUS, 1)
#cap.set(cv2.CAP_PROP_FOCUS, 30)

counter = 1
is_crosshair = False
while True:
    # Read a frame from the camera
    ret, frame = cap.read()
    frame = cv2.resize(frame, (1296,972), interpolation=cv2.INTER_AREA)
    if not ret:
        break
    if counter % 30 == 0:
        is_crosshair = not is_crosshair
        counter = 1
    
    if is_crosshair:
        # Get the dimensions of the frame
        height, width, _ = frame.shape

        # Define the center point
        center_x, center_y = width // 2, height // 2

        # Draw the horizontal line (centered)
        cv2.line(frame, (0, center_y), (width, center_y), (0, 255, 0), 1)  # Green line with thickness 2

        # Draw the vertical line (centered)
        cv2.line(frame, (center_x, 0), (center_x, height), (0, 255, 0), 1)  # Green line with thickness 2


    # Display the frame with the cross
    cv2.imshow("Frame with Cross", frame)


    counter +=1

    # Break the loop if 'q' is pressed
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break
    
    
# Release the video capture and close the window
cap.release()
cv2.destroyAllWindows()
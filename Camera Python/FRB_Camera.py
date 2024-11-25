import cv2
import numpy as np
import time

# Zoom settings
zoom_factor = 1.0
zoom_increment = 0.1
min_zoom = 1.0
max_zoom = 5.0

# Mouse position (initialized at the center)
mouse_x, mouse_y = None, None

# Crosshair settings (if you want to keep them)
counter = 1
is_crosshair = False

def mouse_event(event, x, y, flags, param):
    global zoom_factor, mouse_x, mouse_y

    if event == cv2.EVENT_MOUSEMOVE:
        mouse_x, mouse_y = x, y

    elif event == cv2.EVENT_MOUSEWHEEL:
        if flags > 0:
            zoom_factor += zoom_increment
            if zoom_factor > max_zoom:
                zoom_factor = max_zoom
        else:
            zoom_factor -= zoom_increment
            if zoom_factor < min_zoom:
                zoom_factor = min_zoom

# Initialize camera
cap = cv2.VideoCapture(0)
cap.set(cv2.CAP_PROP_FRAME_WIDTH, 2592)
cap.set(cv2.CAP_PROP_FRAME_HEIGHT, 1944)
time.sleep(2)
cap.set(cv2.CAP_PROP_AUTOFOCUS, 1)

# Create window and set mouse callback
cv2.namedWindow("Zoomed Live View")
cv2.setMouseCallback("Zoomed Live View", mouse_event)

while True:
    ret, frame = cap.read()
    if not ret:
        break

    frame = cv2.resize(frame, (1296, 972), interpolation=cv2.INTER_AREA)
    height, width = frame.shape[:2]

    # Initialize mouse position at the center if not set
    if mouse_x is None or mouse_y is None:
        mouse_x, mouse_y = width // 2, height // 2

    # Update crosshair toggle (if needed)
    if counter % 30 == 0:
        is_crosshair = not is_crosshair
        counter = 1

    counter += 1

    # Calculate ROI dimensions based on zoom factor
    roi_width = int(width / zoom_factor)
    roi_height = int(height / zoom_factor)

    # Ensure ROI does not exceed frame boundaries
    roi_width = min(roi_width, width)
    roi_height = min(roi_height, height)

    # Calculate ROI top-left corner
    x1 = int(mouse_x - roi_width / 2)
    y1 = int(mouse_y - roi_height / 2)

    # Adjust if ROI is out of bounds
    x1 = max(0, min(x1, width - roi_width))
    y1 = max(0, min(y1, height - roi_height))

    x2 = x1 + roi_width
    y2 = y1 + roi_height

    # Extract ROI
    roi = frame[y1:y2, x1:x2]

    # Resize ROI back to window size
    roi_resized = cv2.resize(roi, (width, height), interpolation=cv2.INTER_LINEAR)

    # Draw crosshair if enabled
    if is_crosshair:
        cv2.line(roi_resized, (0, height // 2), (width, height // 2), (0, 255, 0), 1)
        cv2.line(roi_resized, (width // 2, 0), (width // 2, height), (0, 255, 0), 1)

    # Display the zoomed frame
    cv2.imshow("Zoomed Live View", roi_resized)

    # Handle key events
    key = cv2.waitKey(1) & 0xFF
    if key == ord('q'):
        break

cap.release()
cv2.destroyAllWindows()
